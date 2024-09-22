using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.DTOs;
using TaskManagement.DAL.Models;
namespace TaskManagement.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ApplicationUserDTO, ApplicationUser>()
           .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<ApplicationUser, ApplicationUserDTO>()
           .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<ApplicationUser, ApplicationUserDisplayDTO>()
                .ForMember(dest => dest.Tasks, opt => opt
                .MapFrom(src => src.Tasks)); 
            CreateMap<ApplicationUser, EditUserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDisplayDTO>()
                .ForMember(dest => dest.Tasks, opt => opt
                .MapFrom(src => src.Tasks));
            CreateMap<TaskModel, TaskDTO>().ReverseMap();
        }
    }
}
