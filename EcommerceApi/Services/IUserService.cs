using System;
using EcommerceApi.Models;

namespace EcommerceApi.Services
{
	public interface IUserService
	{
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task DeleteUser(int userId);

    }
}

