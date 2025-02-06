using System.Collections.Generic;

namespace Pointman.CarRental.Company.API.Entities
{
    public static class RolePermissions
    {
        public static readonly Dictionary<UserRole, List<UserPermission>> Permissions = new()
        {
            { UserRole.Admin, new List<UserPermission>
                {
                    UserPermission.AddUsers,
                    UserPermission.AddCompanies,
                    UserPermission.DeleteCompanies,
                    UserPermission.EditCompanies,
                    UserPermission.ViewReservations
                }
            },
            { UserRole.CompanyOwner, new List<UserPermission>
                {
                    UserPermission.AddCars,
                    UserPermission.ViewReservations
                }
            },
            { UserRole.Employee, new List<UserPermission>
                {
                    UserPermission.ViewReservations
                }
            },
            { UserRole.IndividualClient, new List<UserPermission>
                {
                    UserPermission.MakeReservations
                }
            }
        };
    }
}
