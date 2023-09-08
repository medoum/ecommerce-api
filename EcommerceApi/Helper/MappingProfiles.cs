using System;
using AutoMapper;
using EcommerceApi.Dto;
using EcommerceApi.Models;

namespace EcommerceApi.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<RegisterDto, User>();
			CreateMap<LoginDto, User>();
			CreateMap<User, LoginDto>();
        }
       
	}
}

