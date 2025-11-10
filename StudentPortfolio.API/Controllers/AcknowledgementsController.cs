using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;
using StudentPortfolio.API.Infrastructure.Validation;
using StudentPortfolio.API.Models;
using StudentPortfolio.API.Models.Dtos.Request;
using StudentPortfolio.API.Models.Dtos.Response;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Repositories;
using StudentPortfolio.API.Repositories.Base;

namespace StudentPortfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcknowledgementsController(
        IAcknowledgementsRepository repo,
        IWebHostEnvironment env,
        IValidator<Acknowledgement, CreateAcknowledgementRequest, UpdateAcknowledgementRequest> validator
    ) : AppControllerBase(env)
    {
        [HttpGet]
        public async Task<IActionResult> Get(ODataQueryOptions<Acknowledgement> opts)
        {
            try
            {
                var query = repo.Get();
                var results = opts.ApplyTo(query) as IQueryable<Acknowledgement>;
                return Ok(results.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var entity = await repo.Get(id);
                return Ok(entity.Adapt<GetAcknowledgementResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAcknowledgementRequest request)
        {
            try
            {
                var validationResult = await validator.ValidateCreate(request);
                if (!validationResult.Success)
                    return BadRequest(validationResult);

                var entity = await repo.Create(request);
                return Ok(entity.Adapt<GetAcknowledgementResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateAcknowledgementRequest request)
        {
            try
            {
                var validationResult = await validator.ValidateUpdate(request);
                if (!validationResult.Success)
                    return BadRequest(validationResult);

                var entity = await repo.Update(id, request);
                return Ok(entity.Adapt<GetAcknowledgementResponse>());
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
