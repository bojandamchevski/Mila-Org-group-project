using DTOs.TrainingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MilaORGApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private IUserService _userService;
        private ITrainingService _trainingService;

        public TrainingController(IUserService userService, ITrainingService trainingService)
        {
            _userService = userService;
            _trainingService = trainingService;
        }

        [HttpPost("take-training")]
        [Authorize(Roles = "2")]
        public IActionResult TakeTraining(int id)
        {
            try
            {
                var claims = User.Claims;
                string userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                int userIdInt = Convert.ToInt32(userId);
                _userService.TakeTraining(id, userIdInt);
                return StatusCode(StatusCodes.Status201Created, "Training added successfully!");
            }
            catch (TrainingException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("create-training")]
        //[Authorize(Roles = "1")]
        public IActionResult Create([FromBody] CreateTrainingDto createTrainingDto)
        {
            try
            {
                _trainingService.CreateTraining(createTrainingDto);
                return StatusCode(StatusCodes.Status201Created, "Training created successfully!");
            }
            catch (TrainingException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("edit-training")]
        [Authorize(Roles = "1")]
        public IActionResult Edit([FromBody] EditTrainingDto editTrainingDto)
        {
            try
            {
                _trainingService.EditTraining(editTrainingDto);
                return StatusCode(StatusCodes.Status202Accepted, "Training edited successfully!");
            }
            catch (TrainingException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("delete-training")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _trainingService.DeleteTraining(id);
                return StatusCode(StatusCodes.Status202Accepted, "Training deleted successfully!");
            }
            catch (TrainingException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
    }
}
