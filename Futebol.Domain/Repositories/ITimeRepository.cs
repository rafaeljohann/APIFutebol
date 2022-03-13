using Futebol.Domain.Entities;

namespace Futebol.Domain.Repositories
{
    public interface ITimeRepository
    {
        IEnumerable<Time> GetAll();
        Time GetById(long id);
        void Create(Time time);
        void Update(Time time);
        void Delete(Time time);
    }
}