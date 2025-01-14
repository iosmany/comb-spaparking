using Microsoft.AspNetCore.Identity.UI.Services;

namespace COMB.SpaParking.UI.Server.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
