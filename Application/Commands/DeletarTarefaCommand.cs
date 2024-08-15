using ESGENDPOINTS.Domain.Entities;
using MediatR;

namespace ESGENDPOINTS.Application.Commands
{
    public class DeletarTarefaCommand: IRequest<Tarefa?>
    {
        public int Id { get; set; }
    }
}
