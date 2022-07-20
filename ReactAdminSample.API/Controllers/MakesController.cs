using Microsoft.AspNetCore.Mvc;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Services;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakesController : AbstractEntityController<Make, MakeFilterDto, IMakeService>
    {
        public MakesController(IMakeService service) : base(service)
        {
        }
    }
}