using ESGENDPOINTS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESGENDPOINTS.Application.Commands
{
    public class EditarTarefaCommand: IRequest<Tarefa>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Status { get; set; }
    }
}
