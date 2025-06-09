using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Pointman.CarRental.Company.API.Models;

namespace Pointman.CarRental.Company.API.Services
{
    public class ContactService : IContactService
    {
        public void SendEmail(ContactRequest request)
        {
            var fromAddress = new MailAddress("rentmo.contact@gmail.com", "RentMo");
            var toAddress = new MailAddress("mat.micz@wp.pl", "Mateusz");
            var userCopyAddress = new MailAddress(request.FromEmail);
            const string fromPassword = "ijdcrtjpyxgpkkef";
            string subject = $"[RentMo Kontakt] {request.Subject}";
            string logoContentId = "logoRentmo";
            string logoPath = @"C:\TempGit\Pointman.CarRental.Web\pointman.carrental.web.client\src\app\Images\png\logo_rentmo.png";

            string bodyHtml = $@"
        <html>
        <head>...</head>  <!-- bez zmian -->
        <body>
            <div class='container'>
                <div class='title'>Nowa wiadomość kontaktowa z RentMo</div>
                <p><span class='label'>Temat:</span> {request.Subject}</p>
                <p><span class='label'>E-mail nadawcy:</span> {request.FromEmail}</p>
                <p><span class='label'>Wiadomość:</span></p>
                <p>{request.Message.Replace("\n", "<br>")}</p>
                <div class='footer'>
                    Wiadomość wygenerowana automatycznie przez system RentMo.<br>
                    <img src='cid:{logoContentId}' alt='RentMo Logo' class='logo'/>
                </div>
            </div>
        </body>
        </html>";

            using var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using var message = new MailMessage
            {
                From = fromAddress,
                Subject = subject,
                IsBodyHtml = true
            };

            message.To.Add(toAddress);

            if (request.SendCopy)
            {
                message.CC.Add(userCopyAddress);
            }

            using var htmlView = AlternateView.CreateAlternateViewFromString(bodyHtml, null, MediaTypeNames.Text.Html);
            var logo = new LinkedResource(logoPath, MediaTypeNames.Image.Png)
            {
                ContentId = logoContentId,
                TransferEncoding = TransferEncoding.Base64
            };

            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);

            smtp.Send(message);
        }
    }
}
