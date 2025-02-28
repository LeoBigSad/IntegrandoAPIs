using System;
using System.Collections.Generic;
using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class Pessoa : Base
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public ICollection<PessoaEndereco> PessoasEnderecos { get; set; } = new List<PessoaEndereco>();
    }

}
