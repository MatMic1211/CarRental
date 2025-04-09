using System.Collections.Generic;

namespace Pointman.CarRental.Company.API.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
        public ICollection<UserRegistration> Users { get; set; } = new List<UserRegistration>();
    }
}
