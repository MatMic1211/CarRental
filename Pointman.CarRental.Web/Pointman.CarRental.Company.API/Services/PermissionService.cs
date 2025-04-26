using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Pointman.CarRental.Company.API.Services
{
    public class PermissionService
    {
        private readonly CarRentalContext _context;

        public PermissionService(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<bool> UserHasPermissionAsync(int userId, string permissionName)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Roles)
                .SelectMany(r => r.Permissions)
                .AnyAsync(p => p.Name == permissionName);
        }
    }
}
