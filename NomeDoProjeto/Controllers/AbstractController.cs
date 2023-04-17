using Microsoft.AspNetCore.Mvc;
using NomeDoProjeto.Services;

namespace NomeDoProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase where T : class
    {
        private readonly ICrudService<T> _service;

        public AbstractController(ICrudService<T> service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult Create(T obj)
        {
            this._service.Create(obj);
            return Created("", obj);
        }

        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(T obj)
        {
            this._service.Update(obj);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._service.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id) => Ok(this._service.Read(id));

        [HttpGet]
        public IActionResult Read() => Ok(this._service.Read());
    }
}