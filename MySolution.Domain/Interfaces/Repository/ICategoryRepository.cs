using MySolution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Domain.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetListAsync();
        Task<Category> GetAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<bool> SaveChangesAsync();
    }
}