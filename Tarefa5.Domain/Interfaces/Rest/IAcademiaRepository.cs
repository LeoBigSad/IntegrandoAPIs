using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Rest
{
    public interface IAcademiaRepository
    {
        Task<IEnumerable<Academia>> GetAllAcademiasAsync();
        Task<Academia> GetAcademiaByIdAsync(Guid id);
        Task<Academia> CreateAcademiaAsync(Academia academia);
        Task<Academia> UpdateAcademiaAsync(Academia academia);
        Task<Academia> DeleteAcademiaAsync(Guid id);
    }
}
