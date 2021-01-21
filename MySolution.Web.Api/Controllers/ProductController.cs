using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySolution.Domain.Entities;
using MySolution.Domain.Interfaces.Services;
using MySolution.Web.Api.DataTransferObjects.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySolution.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        #region Variables
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IEnumerable<ProductResponse>> GetListAsync()
        {
            var products = await _productServices.GetListAsync();

            // Example with AutoMapper
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await _productServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddAsync([FromBody] Product product)
        {
            return await _productServices.AddAsync(product);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Product product)
        {
            return await _productServices.UpdateAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _productServices.DeleteAsync(id);
        }
        #endregion
    }
}