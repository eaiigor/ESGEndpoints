using ESGENDPOINTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESGENDPOINTS.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
