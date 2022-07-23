using Futebol.Domain.Entities;
using Futebol.Domain.Infra.Contexts;
using Futebol.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Futebol.Domain.Infra.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private readonly DataContext _context;
        public TimeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Time>> ObterTodosAsync()
        {
            return await _context.Time
                .AsNoTracking().ToListAsync();
        }

        public async Task<Time> ObterPorIdAsync(int id)
        {
            return await _context.Time
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Time> ObterPorNomeAsync(string nome)
        {
            return await _context.Time
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task CriarAsync(Time time)
        {
            await _context.Time.AddAsync(time);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Time time)
        {
            _context.Entry(time).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Time time)
        {
            _context.Remove(time);
            await _context.SaveChangesAsync();
        }
    }
}