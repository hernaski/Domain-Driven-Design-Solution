using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Entities;
using MySolution.Domain.Interfaces.Repository;
using MySolution.Infrastructure.Context;
using MySolution.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySolution.Infrastructure.Repository
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        #region Constructors
        public ProductRepository(MyDatabaseContext context) : base(context) { }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await base.GetList()
                .Include(p => p.Category)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await base.GetList()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion
    }
}