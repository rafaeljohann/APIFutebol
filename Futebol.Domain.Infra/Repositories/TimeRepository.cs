using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Time>> GetAllAsync()
        {
            return await Task.FromResult(_context.Time
                .AsNoTracking());
        }

        public async Task<Time> GetByIdAsync(long id)
        {
            return await Task.FromResult(_context.Time
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id));
        }

        public void Create(Time time)
        {
            _context.Time.Add(time);
            _context.SaveChanges();
        }

        public void Update(Time time)
        {
            _context.Entry(time).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Time time)
        {
            _context.Remove(time);
            _context.SaveChanges();
        }
    }
}