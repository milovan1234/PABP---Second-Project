﻿using AutoMapper;
using DAL.Models;
using PABP_Second_Project_API.Models;

namespace PABP_Second_Project_API.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierVM>();
            CreateMap<SupplierVM, Supplier>();
        }
    }
}
