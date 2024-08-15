using ESGENDPOINTS.Domain.Entities;

namespace ESGENDPOINTS.Infrastructure.Repositories
{
    public interface ITarefasRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa?> GetByIdAsync(int id);
        Task<Tarefa> createAsync(Tarefa tarefa);
        Task<Tarefa> updateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
