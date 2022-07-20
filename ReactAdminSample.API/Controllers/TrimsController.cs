using Microsoft.AspNetCore.Mvc;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Services;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrimsController : AbstractEntityController<Trim, TrimFilterDto, ITrimService>
    {
        public TrimsController(ITrimService service) : base(service)
        {
        }
    }
}