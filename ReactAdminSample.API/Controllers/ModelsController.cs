using Microsoft.AspNetCore.Mvc;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Services;

namespace ReactAdminSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelsController : AbstractEntityController<Model, ModelFilterDto, IModelService>
    {
        public ModelsController(IModelService service) : base(service)
        {
        }
    }
}