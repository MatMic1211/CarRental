using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Extensions.Configuration;
using Pointman.CarRental.Company.API.Models;
using Pointman.CarRental.Company.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pointman.CarRental.Company.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly CompanyContext _context;

        public EmailService(IConfiguration configuration, CompanyContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string bodyText)
        {
            var fromAddress = new MailAddress(_configuration["Smtp:From"]!, "RentMo");
            var toAddress = new MailAddress(toEmail);
            var logoContentId = "logoRentmo";

            string logoPath = @"C:\TempGit\Pointman.CarRental.Web\pointman.carrental.web.client\src\app\Images\png\logo_rentmo.png";

            string bodyHtml = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f9f9f9;
                            color: #333;
                            padding: 20px;
                        }}
                        .container {{
                            background-color: #fff;
                            border-radius: 8px;
                            border: 1px solid #ccc;
                            padding: 20px;
                            max-width: 600px;
                            margin: auto;
                        }}
                        h2 {{
                            color: #2c3e50;
                        }}
                        .info {{
                            margin-bottom: 10px;
                        }}
                        .footer {{
                            font-size: 12px;
                            color: #888;
                            text-align: center;
                            margin-top: 30px;
                        }}
                        .logo {{
                            margin-top: 10px;
                            width: 100px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Potwierdzenie rezerwacji</h2>
                        <div class='info'>{bodyText.Replace("\n", "<br>")}</div>
                        <div class='footer'>
                            Wiadomość wygenerowana automatycznie przez system RentMo.<br>
                            <img src='cid:{logoContentId}' alt='RentMo Logo' class='logo'/>
                        </div>
                    </div>
                </body>
                </html>";

            using var message = new MailMessage
            {
                From = fromAddress,
                Subject = subject,
                IsBodyHtml = true
            };

            message.To.Add(toAddress);

            var htmlView = AlternateView.CreateAlternateViewFromString(bodyHtml, null, MediaTypeNames.Text.Html);
            var logo = new LinkedResource(logoPath, MediaTypeNames.Image.Png)
            {
                ContentId = logoContentId,
                TransferEncoding = TransferEncoding.Base64
            };

            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);

            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]!),
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
