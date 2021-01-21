using Microsoft.AspNetCore.Mvc;
using MySolution.Domain.Entities;
using MySolution.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        #region Variables
        private readonly ICategoryServices _categoryServices;
        #endregion

        #region Constructors
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _categoryServices.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetAsync(int id)
        {
            return await _categoryServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddAsync([FromBody] Category category)
        {
            return await _categoryServices.AddAsync(category);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Category category)
        {
            return await _categoryServices.UpdateAsync(category);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryServices.DeleteAsync(id);
        }
        #endregion
    }
}