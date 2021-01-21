using MySolution.Domain.Entities;
using MySolution.Domain.Interfaces.Repository;
using MySolution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Services
{
    public sealed class CategoryServices : ICategoryServices
    {
        #region Variables
        private readonly ICategoryRepository _repository;
        #endregion

        #region Constructors
        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            if (id > 0)
                return await _repository.GetAsync(id);
            return null;
        }

        public async Task<bool> AddAsync(Category category)
        {
            await _repository.AddAsync(category);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            ValidateToSave(category, true);

            _repository.Update(category);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _repository.Delete(await GetAsync(id));
            return await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Example for validation of business rules.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="update"></param>
        private void ValidateToSave(Category category, bool update)
        {
            if (update)
            {
                if (category.Id < 1)
                    throw new ApplicationException($"Invalid {nameof(category.Id)} to update the {nameof(category)}.");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ApplicationException($"Empty ({nameof(category.Name)}) for the {nameof(category)}.");
        }
        #endregion
    }
}