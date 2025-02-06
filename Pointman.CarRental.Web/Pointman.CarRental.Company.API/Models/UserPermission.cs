using Pointman.CarRental.Company.API.Attributes;

namespace Pointman.CarRental.Company.API.Entities
{
    public enum UserPermission
    {
        [PermissionDefinition("ADD_USERS")]
        AddUsers,

        [PermissionDefinition("ADD_COMP")]
        AddCompanies,

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
