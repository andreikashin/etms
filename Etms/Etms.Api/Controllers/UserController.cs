using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Etms.Api.Controllers
{
    using Core.Dtos;
    using Core.Entities;
    using Etms.Api.Core.ServiceInterfaces;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
                    IUserService userService,
                    IMapper mapper,
                    IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserDto newUserDto)
        {
            if (newUserDto.Password != newUserDto.ConfirmPassword)
            {
                // return BadRequest(new { message = "Password is not confirmed" });
                return BadRequest(new { message = "Passwords do not match", mustMatch = true });
            }

            // map dto to entity
            var user = _mapper.Map<User>(newUserDto);

            try
            {
                // save 
                _userService.Create(user, newUserDto.Password);
                return Ok(new
                {
                    Username = user.Email
                });
            }
            catch (Exception)
            {
                // return error message if there was an exception
                return BadRequest(new { message = "Error occurred", alreadyTaken = true });
            }
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
            {
                return BadRequest(
                    new
                    {
                        message = "Incorrect Username or password"
                    });
            }

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = user.Token
            });
        }

        [Authorize(Roles = "Admin")]
        // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}