using DTOs.ChapterDtos;
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
    public class ChapterController : ControllerBase
    {
        private IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }


        [HttpPost("create-chapter")]
        [Authorize(Roles = "1")]
        public IActionResult Create([FromBody] CreateChapterDto createChapterDto)
        {
            try
            {
                _chapterService.CreateChapter(createChapterDto);
                return StatusCode(StatusCodes.Status201Created, "Chapter created successfully!");
            }
            catch (ChapterException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("edit-chapter")]
        [Authorize(Roles = "1")]
        public IActionResult Edit([FromBody] EditChapterDto editChapterDto)
        {
            try
            {
                _chapterService.EditChapter(editChapterDto);
                return StatusCode(StatusCodes.Status202Accepted, "Chapter edited successfully!");
            }
            catch (ChapterException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPost("delete-chapter")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _chapterService.DeleteChapter(id);
                return StatusCode(StatusCodes.Status202Accepted, "Chapter deleted successfully!");
            }
            catch (ChapterException e)
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
