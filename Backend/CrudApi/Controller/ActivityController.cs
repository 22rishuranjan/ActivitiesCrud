using Application.DTO;
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
    public class ActivityController : BaseApiController
    {

        private readonly IActivity _activtiy;
        //private readonly DataContext _context;
      

        public ActivityController(IActivity activity) //, DataContext context   ---- used via method dependency injection
        {
            _activtiy = activity;
           // _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Activity()
        {
            return HandleResult(await _activtiy.GetActivities());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Activity(Guid id)
        {
            return HandleResult(await _activtiy.GetActivityById(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await _activtiy.DeleteActivity(id));
        }


        [HttpPost]

        public async Task<IActionResult> Activity(AddActivityDto act)
        {     
            return HandleResult(await _activtiy.AddActivity(act));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Activity(Guid id, UpdateActivityDto act)
        {
            return HandleResult(await _activtiy.UpdateActivity(act,id));
        }



    }
}
