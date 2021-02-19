using AutoMapper;
using MNV.Domain.Entities;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //create mapping
            CreateMap<UserViewModel, User>()
               //.ForMember(dest => dest.Key, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
               //.ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.Now))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName));

            CreateMap<User, UserViewModel>()
               //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

        }
    }
}
