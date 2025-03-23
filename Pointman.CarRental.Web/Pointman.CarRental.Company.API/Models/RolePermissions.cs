using Pointman.CarRental.Company.API.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Pointman.CarRental.Company.API.Entities
{
    public enum RolePermission
    {
        [PermissionDefinition("ADD_USERS")]
        AddUsers,

        [PermissionDefinition("ADD_COMP")]
        AddCompanies,

        [PermissionDefinition("READ_COMP")]
        ReadCompanies,

        [PermissionDefinition("EDI_COMP")]
        EditCompanies,

        [PermissionDefinition("DEL_COMP")]
        DeleteCompanies,

        [PermissionDefinition("ADD_CARS")]
        AddCars,

        [PermissionDefinition("VI_RESER")]
        ViewReservations,

        [PermissionDefinition("MK_RESER")]
        MakeReservations
    }
}
