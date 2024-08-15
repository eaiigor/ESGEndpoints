using ESGENDPOINTS.Application.Commands;
using ESGENDPOINTS.Domain.Entities;
using ESGENDPOINTS.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESGENDPOINTS.Application.Handlers
{
    public class DeletarTarefaHandler : IRequestHandler<DeletarTarefaCommand, Tarefa?>
    {
        private readonly ITarefasRepository _tarefasRepository;

        public DeletarTarefaHandler(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public async Task<Tarefa?> Handle(DeletarTarefaCommand request, CancellationToken cancellationToken)
        {
            await _tarefasRepository.DeleteAsync(request.Id);
            return null;
        }
    }
}
