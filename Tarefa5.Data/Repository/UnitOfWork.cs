using System;
using System.Linq;
using System.Threading.Tasks;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgresDbContext _context;

        public IRepositoryBase<Pessoa> PessoaRepository { get; }
        public IRepositoryBase<Endereco> EnderecoRepository { get; }

        public UnitOfWork(PostgresDbContext context,
                          IRepositoryBase<Pessoa> pessoaRepository,
                          IRepositoryBase<Endereco> enderecoRepository)
        {
            _context = context;
            PessoaRepository = pessoaRepository;
            EnderecoRepository = enderecoRepository;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                await entry.ReloadAsync(); // Agora usa a versão assíncrona
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
