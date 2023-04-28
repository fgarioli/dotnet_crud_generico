using Microsoft.AspNetCore.Mvc;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Repository;
using NomeDoProjeto.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NomeDoProjeto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly ICrudService<T> _service;

        public BaseController(ICrudService<T> service)
        {
            this._service = service;
        }

        [HttpPost]
        [SwaggerResponse(201, "Registro criado.")]
        public ActionResult<T> Create([FromBody] T obj)
        {
            this._service.Create(obj);
            return Created("", obj);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, "Registro atualizado.")]
        [SwaggerResponse(400, "Requisição inválida.")]
        [SwaggerResponse(404, "Registro não encontrado.")]
        public ActionResult<T> Update(int id, [FromBody] T obj)
        {
            this._service.Update(id, obj);
            return Ok(this._service.Read(id));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204, "Registro excluído.")]
        [SwaggerResponse(404, "Registro não encontrado.")]
        public IActionResult Delete(int id)
        {
            this._service.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, "Registro encontrado.")]
        [SwaggerResponse(404, "Registro não encontrado.")]
        public ActionResult<T> Read(int id) => Ok(this._service.Read(id));

        [HttpGet]
        [SwaggerResponse(200, "Registros encontrados.")]
        public ActionResult<Page<T>> Read([FromQuery] IPageQueryDto<T> query) => Ok(this._service.Read(query));
    }
}