﻿using ESGENDPOINTS.Domain.Entities;
using MediatR;

namespace ESGENDPOINTS.Application.Commands
{
    public class CriarTarefaCommand: IRequest<Tarefa>
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Status { get; set; }
    }
}
