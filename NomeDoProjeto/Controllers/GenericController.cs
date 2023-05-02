using MediatR;
using Microsoft.AspNetCore.Mvc;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace NomeDoProjeto.Controllers;

[Route("[controller]")]
// [ApiController]
public class GenericController<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand, TFindByIdQuery, TFindQuery> : ControllerBase
    where TEntity : class
    where TCreateCommand : CreateCommand<TEntity>
    where TUpdateCommand : UpdateCommand<TEntity>
    where TDeleteCommand : DeleteCommand<TEntity>
    where TFindByIdQuery : FindByIdQuery<TEntity>
    where TFindQuery : FindQuery<TEntity>
{
    private readonly IMediator _mediator;

    public GenericController(IMediator mediator) => this._mediator = mediator;

    [HttpPost]
    [SwaggerResponse(201, "Registro criado.")]
    public async Task<ActionResult<TEntity>> Create([FromBody] TCreateCommand command)
    {
        var entity = await this._mediator.Send(command);
        return Created("", entity);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(200, "Registro atualizado.")]
    [SwaggerResponse(400, "Requisição inválida.")]
    [SwaggerResponse(404, "Registro não encontrado.")]
    public async Task<ActionResult<TEntity>> Update(int id, [FromBody] TUpdateCommand command)
    {
        command.Id = id;
        var entity = await this._mediator.Send(command);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(204, "Registro excluído.")]
    [SwaggerResponse(404, "Registro não encontrado.")]
    public async Task<IActionResult> Delete(int id)
    {
        await this._mediator.Send(new DeleteCommand<TEntity>(id));
        return NoContent();
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200, "Registro encontrado.")]
    [SwaggerResponse(404, "Registro não encontrado.")]
    public async Task<ActionResult<TEntity>> FindById(int id) => Ok(await this._mediator.Send(new FindByIdQuery<TEntity>(id)));

    [HttpGet]
    [SwaggerResponse(200, "Registros encontrados.")]
    public async Task<ActionResult<Page<TEntity>>> Find([FromQuery] TFindQuery query) => Ok(await this._mediator.Send(query));
}