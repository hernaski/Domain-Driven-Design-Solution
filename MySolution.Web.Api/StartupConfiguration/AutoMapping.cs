using AutoMapper;
using MySolution.Domain.Entities;
using MySolution.Web.Api.DataTransferObjects.Responses;

namespace MySolution.Web.Api.StartupConfiguration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}