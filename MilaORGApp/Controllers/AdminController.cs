using DTOs.AdminFunctionalitiesDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilaORGApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("get-all-users")]
        [Authorize(Roles = "1")]
        public ActionResult<List<UserListDto>> GetAllUsers()
        {
            try
            {
                return StatusCode(StatusCodes.Status202Accepted, _adminService.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpGet("get-all-trainers")]
        [Authorize(Roles = "1")]
        public ActionResult<List<TrainerListDto>> GetAllTrainers()
        {
            try
            {
                return StatusCode(StatusCodes.Status202Accepted, _adminService.GetAllTrainers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpGet("get-user-by-id")]
        [Authorize(Roles = "1")]
        public ActionResult<UserDetailsDto> GetUserById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status202Accepted, _adminService.GetUserById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpGet("get-trainer-by-id")]
        [Authorize(Roles = "1")]
        public ActionResult<TrainerDetailsDto> GetTrainerById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status202Accepted, _adminService.GetTrainerById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
    }
}
