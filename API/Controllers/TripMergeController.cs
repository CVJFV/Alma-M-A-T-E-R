using System;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize(Roles = "Organiser, Admin")]
    public class TripMergeController : ControllerBase
    {
        private readonly ITripMerge service;

        public TripMergeController(ITripMerge service)
        {
            this.service = service;
        }
        
        // GET
        [HttpGet]
        [Route("canMerge/{id}")]
        public Boolean CanMerge(int id)
        {
            return service.TripCanBeMerged(id);
        }
    }
}