using ESGENDPOINTS.Domain.Entities;
using ESGENDPOINTS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ESGENDPOINTS.Infrastructure.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly ApiDbContext _context;

        public TarefasRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> createAsync(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
            
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
            {
                return;
            }

            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync(int? status)
        {
            return await _context.Tarefa
                .Where(tarefas => status == null || tarefas.Status == status)
                .ToListAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            return tarefa;
        }

        public async Task<Tarefa> updateAsync(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public Task<bool> ExistsAsync(int id) => _context.Tarefa.AnyAsync(e => e.Id == id);
    }
}
