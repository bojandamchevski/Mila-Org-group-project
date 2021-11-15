using DTOs.LoginDto;
using DTOs.RegisterDto;
using DTOs.RoleDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilaORGApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAdminService _adminService;
        private IUserService _userService;
        private ITrainerService _trainerService;

        public AuthenticationController(IAdminService adminService, IUserService userService, ITrainerService trainerService)
        {
            _adminService = adminService;
            _userService = userService;
            _trainerService = trainerService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (registerDto.Role == 1)
                {
                    _adminService.Register(registerDto);
                }
                if (registerDto.Role == 2)
                {
                    _userService.Register(registerDto);
                }
                if (registerDto.Role == 3)
                {
                    _trainerService.Register(registerDto);
                }
                return StatusCode(StatusCodes.Status201Created, "Registered!");
            }
            catch (PersonException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<string> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                RoleDto roleAdmin = _adminService.CheckUserBeforeLogin(loginDto);
                RoleDto roleUser = _userService.CheckUserBeforeLogin(loginDto);
                RoleDto roleTrainer = _trainerService.CheckUserBeforeLogin(loginDto);

                string token = "";

                if (roleAdmin != null)
                {
                    token = _adminService.Login(loginDto);
                }
                if (roleUser != null)
                {
                    token = _userService.Login(loginDto);
                }
                if (roleTrainer != null)
                {
                    token = _trainerService.Login(loginDto);
                }

                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
    }
}
