using DTOs.CategoryDtos;
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
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create-category")]
        //[Authorize(Roles = "1")]
        public IActionResult Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
                _categoryService.CreateCategory(createCategoryDto);
                return StatusCode(StatusCodes.Status201Created, "Category created successfully!");
            }
            catch (CategoryException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("edit-category")]
        [Authorize(Roles = "1")]
        public IActionResult Edit([FromBody] EditCategoryDto editCategoryDto)
        {
            try
            {
                _categoryService.EditCategory(editCategoryDto);
                return StatusCode(StatusCodes.Status202Accepted, "Category edited successfully!");
            }
            catch (CategoryException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("delete-category")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return StatusCode(StatusCodes.Status202Accepted, "Category deleted successfully!");
            }
            catch (CategoryException e)
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
