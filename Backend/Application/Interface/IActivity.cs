using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
   public interface IActivity
    {

        public Task<ApiResponse<List<Activity>>> GetActivities();

        public Task<ApiResponse<Activity>> UpdateActivity(Activity act, Guid id);

        public Task<ApiResponse<Activity>> PatchActivity(Activity act, Guid id);

        public Task<ApiResponse<Activity>> DeleteActivity(Guid id);

        public Task<ApiResponse<Activity>> GetActivityById(Guid id);

        public Task<ApiResponse<List<Activity>>> AddActivity(Activity act);

    }
}
