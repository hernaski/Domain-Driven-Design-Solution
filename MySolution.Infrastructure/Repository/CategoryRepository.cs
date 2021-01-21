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
    public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        #region Constructors
        public CategoryRepository(MyDatabaseContext context) : base(context) { }
        #endregion

        #region Methods
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await base.GetList().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await base.GetAsync(p => p.Id == id);
        }
        #endregion
    }
}