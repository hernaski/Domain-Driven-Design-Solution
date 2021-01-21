using MySolution.Domain.Entities;
using MySolution.Domain.Interfaces.Repository;
using MySolution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Services
{
    public sealed class ProductServices : IProductServices
    {
        #region Variables
        private readonly IProductRepository _repository;
        #endregion

        #region Constructors
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            if (id > 0)
                return await _repository.GetAsync(id);
            return null;
        }

        public async Task<bool> AddAsync(Product product)
        {
            ValidateToSave(product, false);

            await _repository.AddAsync(product);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            ValidateToSave(product, true);

            _repository.Update(product);
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
        /// <param name="product"></param>
        /// <param name="update"></param>
        private void ValidateToSave(Product product, bool update)
        {
            if (update)
            {
                if (product.Id < 1)
                    throw new ApplicationException($"Invalid Id to update {nameof(product)}.");
            }
            else
            {
                product.Id = 0;
                product.RegistrationDate = DateTime.Now;
            }

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ApplicationException($"Empty ({nameof(product.Name)}) for the {nameof(product)}.");

            product.Category = null;
        }
        #endregion
    }
}