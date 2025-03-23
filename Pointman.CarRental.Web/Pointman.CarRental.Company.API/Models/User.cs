using Microsoft.EntityFrameworkCore;
using Pointman.CarRental.Company.API.Entities;
using System.Collections.Generic;

namespace Pointman.CarRental.Company.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
