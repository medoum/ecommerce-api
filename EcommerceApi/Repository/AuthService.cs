using System;
using AutoMapper;
using EcommerceApi.Data;
using EcommerceApi.Dto;
using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repository
{
	public class AuthService : IAuthService
	{
        private readonly EcomDbContext _ecomDbContext;
        private readonly IMapper _mapper;

        public AuthService(EcomDbContext ecomDbContext, IMapper mapper) 
		{
            _ecomDbContext = ecomDbContext;
            _mapper = mapper;
		}

        public async Task<LoginDto> Login(LoginDto loginDto)
        {
            // Mapping the loginDto to a User entity
            var user = new User
            {
                Email = loginDto.Email,
                Password = loginDto.Password
                
            };

            user = await _ecomDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);

            // Check if a user with the provided email and password exists
            if (user == null)
            {
                
                return null; 
            }

            
            await _ecomDbContext.SaveChangesAsync();

            // Mapping the user back to a LoginDto and return it
            return _mapper.Map<LoginDto>(user);
        }


        public async Task<RegisterDto> RegisterUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);

            _ecomDbContext.Users.Add(user);

      
                await _ecomDbContext.SaveChangesAsync();

            return registerDto;
            
        }

    }
}

