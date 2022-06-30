using Microsoft.AspNetCore.Mvc;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Services;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakeController : AbstractEntityController<Make, MakeFilterDto, IMakeService>
    {
        public MakeController(IMakeService service) : base(service)
        {
        }
    }
}