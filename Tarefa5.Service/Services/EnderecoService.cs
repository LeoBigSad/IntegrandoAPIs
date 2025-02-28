using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoService(IEnderecoRepository enderecoRepository, IUnitOfWork unitOfWork)
        {
            _enderecoRepository = enderecoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Endereco>> BuscarTodosAsync()
        {
            return await _enderecoRepository.GetAllAsync();
        }

        public async Task<Endereco> BuscarPorIdAsync(Guid id)
        {
            return await _enderecoRepository.GetByIdAsync(id);
        }

        public async Task<Endereco> CriarAsync(Endereco endereco)
        {
            await _enderecoRepository.InsertAsync(endereco);
            await _unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<Endereco> AtualizarAsync(Endereco endereco)
        {
            _enderecoRepository.Update(endereco);
            await _unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return false;

            _enderecoRepository.Delete(endereco);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }

}
