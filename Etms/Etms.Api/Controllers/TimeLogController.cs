using AutoMapper;
using Etms.Api.Core.Dtos;
using Etms.Api.Core.Entities;
using Etms.Api.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Etms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeLogController : ControllerBase
    {
        private ITimeLogService _timeLogService;
        private IUserService _userService;
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TimeLogController(
            ITimeLogService timeLogService,
            IUserService userService,
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor)
        {
            _timeLogService = timeLogService;
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<TimeLogController>
        //[AllowAnonymous]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TimeLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TimeLogController>
        //[AllowAnonymous]
        [HttpPost]
        public void Post([FromBody] TimeLogDto dto)
        {
            var timeLog = _mapper.Map<TimeLog>(dto);
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            timeLog.User = _userService.GetByEmail(userEmail);
            _timeLogService.Insert(timeLog);
        }

        // PUT api/<TimeLogController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] TimeLogDto dto)
        {
            var modifiedTimeLog = _mapper.Map<TimeLog>(dto);
            modifiedTimeLog.Id = id;



        }
        
        // PUT api/<TimeLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeLogDto dto)
        {
            var modifiedTimeLog = _mapper.Map<TimeLog>(dto);
            modifiedTimeLog.Id = id;



        }

        // DELETE api/<TimeLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
