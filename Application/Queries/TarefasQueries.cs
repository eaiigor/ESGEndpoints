using ESGENDPOINTS.Domain.Entities;
using ESGENDPOINTS.Infrastructure.Repositories;

namespace ESGENDPOINTS.Application.Queries
{
    public class TarefasQueries : ITarefasQueries
    {
        private readonly ITarefasRepository _tarefasRepository;

        public TarefasQueries(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public Task<IEnumerable<Tarefa>> GetAllAsync() => _tarefasRepository.GetAllAsync();

        public Task<Tarefa?> GetByIdAsync(int id) => _tarefasRepository.GetByIdAsync(id);

        public Task<bool> ExistsAsync(int id) => _tarefasRepository.ExistsAsync(id);
    }
}
