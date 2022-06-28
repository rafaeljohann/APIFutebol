using Futebol.Domain.Entities;

namespace Futebol.Domain.Repositories
{
    public interface ITimeRepository
    {
        Task<IEnumerable<Time>> GetAllAsync();
        Task<Time> GetByIdAsync(long id);
        void Create(Time time);
        void Update(Time time);
        void Delete(Time time);
    }
}