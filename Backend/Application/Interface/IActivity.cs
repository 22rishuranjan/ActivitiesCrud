using Application.DTO;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
   public interface IActivity
    {

        public Task<ApiResponse<List<GetActivityDto>>> GetActivities();

        public Task<ApiResponse<GetActivityDto>> UpdateActivity(UpdateActivityDto act, Guid id);



        public Task<ApiResponse<GetActivityDto>> DeleteActivity(Guid id);

        public Task<ApiResponse<GetActivityDto>> GetActivityById(Guid id);

        public Task<ApiResponse<List<GetActivityDto>>> AddActivity(AddActivityDto act);

    }
}
