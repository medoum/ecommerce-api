using System;
using EcommerceApi.Dto;
using EcommerceApi.Models;

namespace EcommerceApi.Services
{
	public interface IAuthService
	{
		Task<User> RegisterUser(RegisterDto registerDto);
		Task<User> Login(LoginDto loginDto);
	}

}

