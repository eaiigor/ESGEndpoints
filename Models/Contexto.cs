using Microsoft.EntityFrameworkCore;

namespace ESGENDPOINTS.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {

        }

        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
