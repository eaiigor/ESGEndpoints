using ESGENDPOINTS.Domain.Entities;

namespace ESGENDPOINTS.Application.Queries
{
    public interface ITarefasQueries
    {
        Task<Tarefa?> GetByIdAsync(int id);
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
    }
}
