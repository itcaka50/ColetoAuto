using Microsoft.AspNetCore.Identity.UI.Services;

namespace MVC.Managers
{
    public class EmailSenderManager : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
