using System.Threading.Tasks;
using Detetive_API.Models;

namespace Detetive_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool> SaveChangesAsync();
        Task<Suspeito[]> GetAllSuspeitos();
        Task<Local[]> GetAllLocais();
        Task<Arma[]> GetAllArmas();
        Task<SolucaoCrime> GetSolucaoCrime(int id);
    }
}