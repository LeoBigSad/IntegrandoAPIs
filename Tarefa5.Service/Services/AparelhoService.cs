using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;
using Tarefa5.Domain.Interfaces.Rest;

namespace Tarefa5.Application.Services
{
    public class AparelhoService : IAparelhoService
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        public AparelhoService(IAparelhoRepository aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        public async Task<IEnumerable<Aparelho>> BuscarTodosAsync()
        {
            return await _aparelhoRepository.GetAllAparelhoAsync();
        }

        public async Task<Aparelho> BuscarPorIdAsync(Guid id)
        {
            return await _aparelhoRepository.GetAparelhoByIdAsync(id);
        }

        public async Task<Aparelho> CriarAsync(Aparelho aparelho)
        {
            return await _aparelhoRepository.CreateAparelhoAsync(aparelho);
        }

        public async Task<Aparelho> AtualizarAsync(Aparelho aparelho)
        {
            return await _aparelhoRepository.UpdateAparelhoAsync(aparelho);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var aparelho = await _aparelhoRepository.DeleteAparelhoAsync(id);
            return aparelho != null;
        }
    }
}
