using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Dto.Response;
using ReactAdminSample.Domain.Extensions;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakeController : ControllerBase
    {
        private readonly SampleDbContext _dbContext;

        public MakeController(SampleDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListRequestDto<MakeFilterDto> request)
        {
            //TODO: Use service/repository pattern instead
            var query = _dbContext.Makes.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Filter?.Name))
                query = query.Where(m => EF.Functions.Like(m.Name, request.Filter.Name));

            var total = await query.CountAsync();

            query = query.ApplySorting(request);

            var toSkip = (request.PageIndex - 1) * request.PageSize;
            query = query.Skip(toSkip).Take(request.PageSize);

            return Ok(new GetListResponseDto<Make>() {
                Data = await query.ToListAsync(),
                Total = total,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Make model)
        {
            
            return Ok();
        }
    }
}