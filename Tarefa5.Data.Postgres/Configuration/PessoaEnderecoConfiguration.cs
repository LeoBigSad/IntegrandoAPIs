using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Postgres.Configuration
{
    public class PessoaEnderecoConfiguration : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.ToTable("PessoaEndereco");

            builder.HasKey(pe => new { pe.PessoaId, pe.EnderecoId });

            builder.HasOne(pe => pe.Pessoa)
                .WithMany(p => p.PessoasEnderecos)
                .HasForeignKey(pe => pe.PessoaId);

            builder.HasOne(pe => pe.Endereco)
                .WithMany(e => e.PessoasEnderecos)
                .HasForeignKey(pe => pe.EnderecoId);
        }
    }
}
