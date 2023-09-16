using EcommerceApi.Dto;
using EcommerceApi.Models;

namespace EcommerceApi.Abstract
{
	public interface IJwtUtils
	{
        string GenerateJwtToken(User user);
        int ValidateJwtToken(string token);
    }
}

