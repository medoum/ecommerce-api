using System;
using EcommerceApi.Dto;

namespace EcommerceApi.Services
{
	public interface IAuthService
	{
		Task<RegisterDto> RegisterUser(RegisterDto registerDto);
		Task<LoginDto> Login(LoginDto loginDto);
	}

}

