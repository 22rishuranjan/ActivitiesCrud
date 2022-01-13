using Application.Interface;
using CrudApi.Filters;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ActivityController : ControllerBase
    {

        private readonly IActivity _activtiy;
        //private readonly DataContext _context;
      

        public ActivityController(IActivity activity) //, DataContext context   ---- used via method dependency injection
        {
            _activtiy = activity;
           // _context = context;
        }


        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> Activity()
        {
            return Ok(await _activtiy.GetActivities());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Activity(Guid id)
        {
            return Ok(await _activtiy.GetActivityById(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await _activtiy.DeleteActivity(id));
        }


        [HttpPost]

        public async Task<IActionResult> Activity(Activity act)
        {
            var contentType = this.Request.ContentType;

            return Ok(await _activtiy.AddActivity(act));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Activity(Guid id, Activity act)
        {
            return Ok(await _activtiy.UpdateActivity(act,id));
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Activity(Guid id, [FromBody]JsonPatchDocument<Activity> act, [FromServices] DataContext _context)
        {
            //return Ok(await _activtiy.PatchActivity(act, id));

            var _act = await _context.Activities.FindAsync(id);
            if (act == null)
            {
                return NotFound();
            }

            act.ApplyTo(_act, ModelState);

            var model = new
            {
                original = _act,
                patched = act
            };
            return Ok(await _activtiy.UpdateActivity(_act, id));



          //  return Ok(model);

        }

    }
}
