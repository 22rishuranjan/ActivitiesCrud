using Application.DTO;
using Application.Interface;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ActivityService : IActivity
    {

        
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public ActivityService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ApiResponse<List<GetActivityDto>>> AddActivity(AddActivityDto act)
        {
            ApiResponse<List<GetActivityDto>> res = new ApiResponse<List<GetActivityDto>>();
            Activity _act = _mapper.Map<Activity>(act);
            _context.Add(_act);
            await _context.SaveChangesAsync();
            res.Data = await _context.Activities.Select(c => _mapper.Map<GetActivityDto>(c)).ToListAsync();
            res.Message = "Success: Acivtity added!";
            res.Success = true;

            return res;
        }

        public async Task<ApiResponse<GetActivityDto>> DeleteActivity(Guid id)
        {
            ApiResponse<GetActivityDto> res = new ApiResponse<GetActivityDto>();

            var act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = true;

                return res;

            }

            res.Data = _mapper.Map<GetActivityDto>( act);
            res.Message = "Activity deleted!!";
            res.Success = true;

            _context.Remove(act);
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<ApiResponse<List<GetActivityDto>>> GetActivities()
        {
            ApiResponse<List<GetActivityDto>> res = new ApiResponse<List<GetActivityDto>>();
            res.Data =  await _context.Activities.Select(c => _mapper.Map<GetActivityDto>(c)).ToListAsync();
            res.Message = "List fectched!!";
            res.Success = true;

            return res;
        }

        public async Task<ApiResponse<GetActivityDto>> GetActivityById(Guid id)
        {
            ApiResponse<GetActivityDto> res = new ApiResponse<GetActivityDto>();

            var act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = false;

                return res;

            }
            res.Data = _mapper.Map<GetActivityDto>(act);
            res.Message = "Activity found!!";
            res.Success = true;

            return res;
        }

       
        public async Task<ApiResponse<GetActivityDto>> UpdateActivity(UpdateActivityDto act, Guid id)
        {
            ApiResponse<GetActivityDto> res = new ApiResponse<GetActivityDto>();

            var _act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = false;

                return res;
            }

            _mapper.Map(act, _act);
            await _context.SaveChangesAsync();
            res.Data = _mapper.Map<GetActivityDto>(await _context.Activities.FindAsync(id));
            res.Message = "Success, Activitity is successfully updated.";
            res.Success = true;
            return res;
        }
    }
}
