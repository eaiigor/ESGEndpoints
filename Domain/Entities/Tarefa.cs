using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESGENDPOINTS.Domain.Entities
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Titulo")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Column("DataVencimento")]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public int Status { get; set; }
    }
}
