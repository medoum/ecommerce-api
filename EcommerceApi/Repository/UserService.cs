using System;
using EcommerceApi.Data;
using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repository
{
	public class UserService : IUserService
	{
        private readonly EcomDbContext _dbContext;

        public UserService(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

