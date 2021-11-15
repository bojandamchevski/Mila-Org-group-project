using DTOs.ResearchDtos;
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
    public class ResearchController : ControllerBase
    {
        private IResearchService _researchService;

        public ResearchController(IResearchService researchService)
        {
            _researchService = researchService;
        }

        [HttpPost("create-research")]
        [Authorize(Roles = "1")]
        public IActionResult Create([FromBody] CreateResearchDto createResearchDto)
        {
            try
            {
                _researchService.CreateResearch(createResearchDto);
                return StatusCode(StatusCodes.Status201Created, "Research created successfully!");
            }
            catch (ResearchException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("edit-research")]
        [Authorize(Roles = "1")]
        public IActionResult Edit([FromBody] EditResearchDto editResearchDto)
        {
            try
            {
                _researchService.EditResearch(editResearchDto);
                return StatusCode(StatusCodes.Status202Accepted, "Research edited successfully!");
            }
            catch (ResearchException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("delete-research")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _researchService.DeleteResearch(id);
                return StatusCode(StatusCodes.Status202Accepted, "Research deleted successfully!");
            }
            catch (ResearchException e)
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
