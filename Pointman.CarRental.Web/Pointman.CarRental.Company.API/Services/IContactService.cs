using Pointman.CarRental.Company.API.Entities;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public interface IContactService
    {
        void SendEmail(ContactRequest request);
    }
}
