using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class PessoaEndereco
    {
        public Guid PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
