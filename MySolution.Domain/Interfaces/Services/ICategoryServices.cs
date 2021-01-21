using MySolution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Domain.Interfaces.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetListAsync();
        Task<Category> GetAsync(int id);
        Task<bool> AddAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}