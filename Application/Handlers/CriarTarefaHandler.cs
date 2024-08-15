using ESGENDPOINTS.Application.Commands;
using ESGENDPOINTS.Domain.Entities;
using ESGENDPOINTS.Infrastructure.Repositories;
using MediatR;

namespace ESGENDPOINTS.Application.Handlers
{
    public class CriarTarefaHandler : IRequestHandler<CriarTarefaCommand, Tarefa>
    {
        private readonly ITarefasRepository _tarefasRepository;

        public CriarTarefaHandler(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public async Task<Tarefa> Handle(CriarTarefaCommand request, CancellationToken cancellationToken)
        {
            Tarefa tarefa = new Tarefa()
            {
                DataVencimento = request.DataVencimento,
                Descricao = request.Descricao,
                Status = request.Status,
                Titulo = request.Titulo,
            };

            await _tarefasRepository.createAsync(tarefa);
            return tarefa;
        }
    }
}
