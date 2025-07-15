
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.ViewModels;

namespace Pointman.CarRental.Company.API.Mappers
{
    public class ContactRequestMapper : IContactRequestMapper
    {
        public ContactRequestViewModel MapToViewModel(ContactRequest entity)
        {
            return new ContactRequestViewModel
            {
                FromEmail = entity.FromEmail,
                Subject = entity.Subject,
                Message = entity.Message,
                SendCopy = entity.SendCopy
            };
        }

        public ContactRequest MapToEntity(ContactRequestViewModel viewModel)
        {
            return new ContactRequest
            {
                FromEmail = viewModel.FromEmail,
                Subject = viewModel.Subject,
                Message = viewModel.Message,
                SendCopy = viewModel.SendCopy
            };
        }
    }
}
