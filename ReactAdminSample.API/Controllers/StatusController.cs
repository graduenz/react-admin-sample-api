using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        public StatusController(SampleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SampleDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new {
                Healthy = true,
                Makes = await DbContext.Makes.CountAsync(),
                Models = await DbContext.Models.CountAsync(),
                Trims = await DbContext.Trims.CountAsync(),
            });
        }
    }
}
