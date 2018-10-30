

using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("platonowdmitry@gmail.com", "Dmitry Platonov");
            var subject = message.Subject;
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            // Send the email.
            if (client != null)
            {
                await client.SendEmailAsync(msg);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }

        }
    }
}
