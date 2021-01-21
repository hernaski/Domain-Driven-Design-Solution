using MySolution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Domain.Interfaces.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetListAsync();
        Task<Product> GetAsync(int id);
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}