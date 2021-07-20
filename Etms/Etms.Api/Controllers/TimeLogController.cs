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
        public IActionResult Get()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = _userService.GetByEmail(userEmail);

            if (user.Role?.Name == "Admin")
            {
                var logs = _timeLogService.GetAll();
                return Ok(_mapper.Map<TimeLogDto>(logs));
            }

            var timeLogs = _timeLogService.GetAllByUser(user);

            if (timeLogs.Any())
            {
                var dtoList = timeLogs.Select(_mapper.Map<TimeLogDto>);
                return Ok(dtoList);
            }

            return NotFound();
        }

        // GET api/<TimeLogController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = _userService.GetByEmail(userEmail);
            var timeLog = _timeLogService.FindById(id);

            if (user.Role?.Name == "Admin" ||
                timeLog.User == user)
            {
                return Ok(_mapper.Map<TimeLogDto>(timeLog));
            }

            return NotFound(id);
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

        // PATCH api/<TimeLogController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] TimeLogDto dto)
        {
            var modifiedTimeLog = _mapper.Map<TimeLog>(dto);
            modifiedTimeLog.Id = id;

            var existingLog = _timeLogService.FindById(id);
            if (!string.IsNullOrWhiteSpace(modifiedTimeLog.Description))
            {
                existingLog.Description = modifiedTimeLog.Description;
            }

            if (modifiedTimeLog.StartTime != default(DateTimeOffset) &&
                modifiedTimeLog.StartTime != existingLog.StartTime)
            {
                existingLog.StartTime = modifiedTimeLog.StartTime;
            }

            if (modifiedTimeLog.EndTime != null &&
                modifiedTimeLog.EndTime != default(DateTimeOffset) &&
                modifiedTimeLog.EndTime != existingLog.EndTime)
            {
                existingLog.EndTime = modifiedTimeLog.EndTime;
            }

            _timeLogService.UpdateTimeLog();
        }

        // PUT api/<TimeLogController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TimeLogDto dto)
        {
            var existingLog = _timeLogService.FindById(id);
            existingLog.StartTime = dto.StartTime;
            existingLog.EndTime = dto.EndTime;
            existingLog.Description = dto.Description;
            _timeLogService.UpdateTimeLog();

            return Ok(_mapper.Map<TimeLogDto>(existingLog));
        }

        // DELETE api/<TimeLogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = _userService.GetByEmail(userEmail);
            var timeLog = _timeLogService.FindById(id);

            if (user.Role?.Name == "Admin" ||
                timeLog?.User == user)
            {
                _timeLogService.DeleteById(id);
                return Ok();
            }

            return NotFound();
        }
    }
}
