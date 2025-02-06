using System;

namespace Pointman.CarRental.Company.API.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PermissionDefinitionAttribute : Attribute
    {
        public string Code { get; }

        public PermissionDefinitionAttribute(string code)
        {
            Code = code;
        }
    }
}
