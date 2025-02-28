using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;
namespace Tarefa5.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PessoaService(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork)
        {
            _pessoaRepository = pessoaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Pessoa>> BuscarTodosAsync()
        {
            return await _pessoaRepository.GetAllAsync();
        }

        public async Task<Pessoa> BuscarPorIdAsync(Guid id)
        {
            return await _pessoaRepository.BuscarComEnderecosAsync(id);
        }

        public async Task<Pessoa> CriarAsync(Pessoa pessoa)
        {
            foreach (var pessoaEndereco in pessoa.PessoasEnderecos)
            {
                pessoaEndereco.PessoaId = pessoa.Id;
            }

            await _pessoaRepository.InsertAsync(pessoa);
            await _unitOfWork.CommitAsync();
            return pessoa;
        }



        public async Task<Pessoa> AtualizarAsync(Pessoa pessoa)
        {
            _pessoaRepository.Update(pessoa);
            await _unitOfWork.CommitAsync();
            return pessoa;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(id);
            if (pessoa == null) return false;

            _pessoaRepository.Delete(pessoa);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }

}
