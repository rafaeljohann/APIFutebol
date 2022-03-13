using Futebol.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Futebol.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Time> Time { get; set; }
    }
}