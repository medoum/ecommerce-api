using AutoMapper;
using EcommerceApi.Abstract;
using EcommerceApi.Data;
using EcommerceApi.Dto;
using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace EcommerceApi.Repository
{
	public class AuthService : IAuthService
	{
        private readonly EcomDbContext _ecomDbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtUtils _jwtUtils;
        public AuthService(EcomDbContext ecomDbContext, IMapper mapper, IPasswordHasher passwordHasher) 
		{
            _ecomDbContext = ecomDbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtUtils = _jwtUtils;
		}

        public async Task<User> Login(LoginDto loginDto)
        {
            // Find the email that user provides
            var user = await _ecomDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            var token = _jwtUtils.GenerateJwtToken(user);

            if (user == null)
            {
                throw new Exception("Email incorrect");
            }

            // Verify the provided plaintext password against the hashed password in the database
            var passwordVerificationResult = _passwordHasher.Verify(user.Password, loginDto.Password);
            
            if (!passwordVerificationResult)
            {
                throw new Exception("Mot de passe incorrect");
            }

            await _ecomDbContext.SaveChangesAsync();

            //var token = _jwtUtils.GenerateJwtToken(loginDto);



            return user;
        }

        public async Task<User> RegisterUser(RegisterDto registerDto)
        {
    
            var passwordhasher = _passwordHasher.Hash(registerDto.Password);


            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Address = registerDto.Address,
                Phone = registerDto.Phone,
                Password = passwordhasher,
          
                
            };
            _ecomDbContext.Users.Add(user);

            await _ecomDbContext.SaveChangesAsync();

            var token = _jwtUtils.GenerateJwtToken(user);

            user.Token = token;

            return user;
        }


    }
}

