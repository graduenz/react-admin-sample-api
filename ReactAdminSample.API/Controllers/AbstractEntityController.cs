using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Services;

namespace ReactAdminSample.API.Controllers
{
    public abstract class AbstractEntityController<TEntity, TFilter, TService> : ControllerBase
        where TEntity : class, IEntity, new()
        where TFilter : class, IEntityFilter
        where TService : IEntityService<TEntity, TFilter>
    {
        public AbstractEntityController(TService service)
        {
            Service = service;
        }

        protected TService Service { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var entity = await Service.GetOneAsync(id);

            return entity == null
                ? NotFound()
                : Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] GetManyRequestDto<TFilter> request)
        {
            var result = await Service.GetManyAsync(request);

            if (result.RangeEnd > 0)
            {
                Response.Headers.ContentRange = new ContentRangeHeaderValue(result.RangeStart, result.RangeEnd, result.Total) {
                    Unit = typeof(TEntity).Name,
                }.ToString();
            }

            return Ok(result.Entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntity entity)
        {
            var response = await Service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetOne), new { id = response?.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TEntity entity)
        {
            var updatedEntity = await Service.UpdateAsync(id, entity);

            return updatedEntity == null
                ? NotFound()
                : Ok(updatedEntity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromQuery] IList<Guid> ids, [FromBody] TEntity entity) =>
            Ok(await Service.UpdateManyAsync(ids, entity));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedEntity = await Service.DeleteAsync(id);

            return deletedEntity == null
                ? NotFound()
                : Ok(deletedEntity);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMany([FromQuery] IList<Guid> ids) =>
            Ok(await Service.DeleteManyAsync(ids));
    }
}
