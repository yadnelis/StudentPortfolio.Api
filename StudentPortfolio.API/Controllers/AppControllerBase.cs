using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace StudentPortfolio.API.Controllers
{
    public class AppControllerBase(IWebHostEnvironment env, ILogger logger) : ControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(new
            {
                Entity = value,
                Time = DateTime.UtcNow,
                Resource = HttpContext.Request.Path,
            });
        }

        public new OkObjectResult Ok()
        {
            return base.Ok(new
            {
                Time = DateTime.UtcNow,
                Resource = HttpContext.Request.Path,
            });
        }

        public BadRequestObjectResult BadRequest([ActionResultObjectValue] Exception error)
        {
            if(env.IsDevelopment())
            {
                return base.BadRequest(new
                {
                    Time = DateTime.UtcNow,
                    Resource = HttpContext.Request.Path,
                    Exception = error
                });
            }
            else
            {
                return base.BadRequest(new
                {
                    Time = DateTime.UtcNow,
                    Resource = HttpContext.Request.Path
                });
            }
        }
    }
}
