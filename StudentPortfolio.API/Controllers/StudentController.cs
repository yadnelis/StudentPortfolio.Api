﻿using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortfolio.API.Models.Dtos.Request;
using StudentPortfolio.API.Models.Dtos.Response;
using StudentPortfolio.API.Repositories;

namespace StudentPortfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentsRepository repo, IWebHostEnvironment env)
       : AppControllerBase(env)
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var entity = await repo.Get(id);
                return Ok(entity.Adapt<GetStudentResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentRequest request)
        {
            try
            {
                var entity = await repo.Create(request);
                return Ok(entity.Adapt<GetStudentResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStudentRequest request)
        {
            try
            {
                var entity = await repo.Update(id, request);
                return Ok(entity.Adapt<GetStudentResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
