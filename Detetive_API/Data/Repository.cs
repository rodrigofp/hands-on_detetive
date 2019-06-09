using System;
using System.Linq;
using System.Threading.Tasks;
using Detetive_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Detetive_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get;}
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return(await _context.SaveChangesAsync() > 0);
        }

        public async Task<Suspeito[]> GetAllSuspeitos()
        {
            IQueryable<Suspeito> query = _context.Suspeitos;

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Local[]> GetAllLocais()
        {
            IQueryable<Local> query = _context.Locais;

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Arma[]> GetAllArmas()
        {
            IQueryable<Arma> query = _context.Armas;

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<SolucaoCrime> GetSolucaoCrime(int id)
        {
            IQueryable<SolucaoCrime> query = _context.SolucaoCrimes;

            query = query.AsNoTracking().Where(sc => sc.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}