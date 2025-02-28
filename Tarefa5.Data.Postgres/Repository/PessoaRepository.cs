using Microsoft.EntityFrameworkCore;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Postgres.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        private readonly PostgresDbContext _context;

        public PessoaRepository(PostgresDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pessoa> BuscarComEnderecosAsync(Guid id)
        {
            return await _context.Pessoas
                .Include(p => p.PessoasEnderecos)
                .ThenInclude(pe => pe.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
