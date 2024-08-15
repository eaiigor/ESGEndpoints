using ESGENDPOINTS.Application.Commands;
using ESGENDPOINTS.Application.Queries;
using ESGENDPOINTS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESGENDPOINTS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {

        public TarefasController() { }

        // GET: api/Tarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas(
            [FromQuery] int? status,
            [FromServices] ITarefasQueries queries) => Ok(await queries.GetAllAsync(status));

        // GET: api/Tarefas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id, [FromServices] ITarefasQueries queries)
        {
            var tarefa = await queries.GetByIdAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // POST: api/Tarefas
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa([FromBody] CriarTarefaCommand command, 
            [FromServices] IMediator mediator)
        {
            if (command == null)
            {
                return BadRequest("Tarefa não pode ser nula.");
            }

            var tarefa = await mediator.Send(command);
            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/Tarefas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, 
            [FromBody] EditarTarefaCommand command, 
            [FromServices] IMediator mediator,
            [FromServices] ITarefasQueries queries)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }            

            if(!(await queries.ExistsAsync(id)))
            {
                return NotFound();
            }

            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Tarefas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id,
            [FromServices] IMediator mediator,
            [FromServices] ITarefasQueries queries)
        {
            if (!(await queries.ExistsAsync(id)))
            {
                return NotFound();
            }

            var cmd = new DeletarTarefaCommand()
            {
                Id = id,
            };

            await mediator.Send(cmd);
            return NoContent();
        }
    }
}