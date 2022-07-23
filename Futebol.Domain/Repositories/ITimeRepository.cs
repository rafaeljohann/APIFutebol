using Futebol.Domain.Entities;

namespace Futebol.Domain.Repositories
{
    public interface ITimeRepository
    {
        Task<IEnumerable<Time>> ObterTodosAsync();
        Task<Time> ObterPorIdAsync(int id);
        Task<Time> ObterPorNomeAsync(string nome);
        Task CriarAsync(Time time);
        Task AtualizarAsync(Time time);
        Task ExcluirAsync(Time time);
    }
}