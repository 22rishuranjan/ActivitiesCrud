using Application.Interface;
using AutoMapper;
using Domain;
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

        public async Task<ApiResponse<List<Activity>>> AddActivity(Activity act)
        {
            ApiResponse<List<Activity>> res = new ApiResponse<List<Activity>>();

            _context.Add(act);
            await _context.SaveChangesAsync();
            res.Data = await _context.Activities.ToListAsync();
            res.Message = "Success: Acivtity added!";
            res.Success = true;

            return res;
        }

        public async Task<ApiResponse<Activity>> DeleteActivity(Guid id)
        {
            ApiResponse<Activity> res = new ApiResponse<Activity>();

            var act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = true;

                return res;

            }

            res.Data = act;
            res.Message = "Activity deleted!!";
            res.Success = true;

            _context.Remove(act);
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<ApiResponse<List<Activity>>> GetActivities()
        {
            ApiResponse<List<Activity>> res = new ApiResponse<List<Activity>>();
            res.Data =  await _context.Activities.ToListAsync();
            res.Message = "List fectched!!";
            res.Success = true;

            return res;
        }

        public async Task<ApiResponse<Activity>> GetActivityById(Guid id)
        {
            ApiResponse<Activity> res = new ApiResponse<Activity>();

            var act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = false;

                return res;

            }
            res.Data = act;
            res.Message = "Activity found!!";
            res.Success = true;

            return res;
        }

        public async Task<ApiResponse<Activity>> PatchActivity(Activity act, Guid id)
        {
            ApiResponse<Activity> res = new ApiResponse<Activity>();

            var _act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                res.Data = null;
                res.Message = "Error: Acivtity can not be found!";
                res.Success = false;

                return res;
            }

            //_mapper.Map(act, _act);
            await _context.SaveChangesAsync();
            res.Data = await _context.Activities.FindAsync(id);
            res.Message = "Success, Activitity is successfully patched.";
            res.Success = true;
            return res;
        }

        public async Task<ApiResponse<Activity>> UpdateActivity(Activity act, Guid id)
        {
            ApiResponse<Activity> res = new ApiResponse<Activity>();

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
            res.Data = await _context.Activities.FindAsync(id);
            res.Message = "Success, Activitity is successfully updated.";
            res.Success = true;
            return res;
        }
    }
}
