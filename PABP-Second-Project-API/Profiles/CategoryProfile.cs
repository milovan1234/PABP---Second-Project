using AutoMapper;
using DAL.Models;
using PABP_Second_Project_API.Models;

namespace PABP_Second_Project_API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }        
    }
}
