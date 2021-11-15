using DTOs.BlogDtos;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("create-blog")]
        //[Authorize(Roles = "1")]
        public IActionResult Create([FromBody] CreateBlogDto createBlogDto)
        {
            try
            {
                _blogService.CreateBlog(createBlogDto);
                return StatusCode(StatusCodes.Status201Created, "Blog created successfully!");
            }
            catch (BlogException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("edit-blog")]
        [Authorize(Roles = "1")]
        public IActionResult Edit([FromBody] EditBlogDto editBlogDto)
        {
            try
            {
                _blogService.EditBlog(editBlogDto);
                return StatusCode(StatusCodes.Status202Accepted, "Blog edited successfully!");
            }
            catch (BlogException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("delete-blog")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _blogService.DeleteBlog(id);
                return StatusCode(StatusCodes.Status202Accepted, "Blog deleted successfully!");
            }
            catch (BlogException e)
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
