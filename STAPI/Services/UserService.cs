using Microsoft.EntityFrameworkCore;
using STAPI.Data;
using STAPI.Models;
using STAPI.DTOs;
using System.Threading.Tasks;

namespace STAPI.Services
{
    public class UserService
    {
        private readonly StockGameDbContext _context;

        public UserService(StockGameDbContext context)
        {
            _context = context;
        }

        public async Task<int?> LoginAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public async Task CreateUserAsync(string name)
        {
            var user = new User { Name = name, CurrencyABalance = 1000, CurrencyBBalance = 1000 };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userRegistrationDto.Id);
            if (existingUser != null)
            {
                return false; // 既に同じIDのユーザーが存在する場合
            }

            var user = new User
            {
                Id = userRegistrationDto.Id,
                Name = userRegistrationDto.Name,
                CurrencyABalance = 1000,
                CurrencyBBalance = 1000
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
