using AutoMapper;
using DomainLayer.Models;
using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Configurations
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Owner, OwnerVM>().ReverseMap();
        }
    }
}
