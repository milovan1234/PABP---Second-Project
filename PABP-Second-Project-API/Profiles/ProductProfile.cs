using AutoMapper;
using DAL.Models;
using PABP_Second_Project_API.Models;

namespace PABP_Second_Project_API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
            CreateMap<ProductCreateVM, Product>();
            CreateMap<Product, ProductCreateVM>();
        }
    }
}
