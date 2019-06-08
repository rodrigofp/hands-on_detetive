using Detetive_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Detetive_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Suspeito> Suspeitos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Arma> Armas { get; set; }
    }
}