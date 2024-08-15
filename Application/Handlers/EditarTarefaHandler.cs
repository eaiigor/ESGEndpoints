using ESGENDPOINTS.Application.Commands;
using ESGENDPOINTS.Domain.Entities;
using ESGENDPOINTS.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESGENDPOINTS.Application.Handlers
{
    public class EditarTarefaHandler : IRequestHandler<EditarTarefaCommand, Tarefa>
    {
        private readonly ITarefasRepository _tarefasRepository;

        public EditarTarefaHandler(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public async Task<Tarefa> Handle(EditarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefasRepository.GetByIdAsync(request.Id);

            tarefa!.Titulo = request.Titulo;
            tarefa.Status = request.Status;
            tarefa.Descricao = request.Descricao;
            tarefa.DataVencimento = request.DataVencimento;

            await _tarefasRepository.updateAsync(tarefa);

            return tarefa;
        }
    }
}
