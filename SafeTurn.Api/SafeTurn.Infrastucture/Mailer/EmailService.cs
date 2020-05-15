using System.Reflection;
using System.Threading.Tasks;
using FluentEmail.Core;
using SafeTurn.Application.Interfaces.Infrastucture;
using SafeTurn.Infrastucure.Mailer.Models;

namespace SafeTurn.Infrastucure.Mailer
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _smtpClient;
        public EmailService(IFluentEmail smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendRegisterConfirmationEmailAsync(string email, string name, string callbackUrl, string clientUrl)
        {
            await SendEmailWithCallbackUrlAsync(
                email,
                new RegisterConfirmation()
                {
                    Name = name,
                    CallbackUrl = callbackUrl
                },
                "Confrimacion de registro",
                "SafeTurn.Infrastucure.Mailer.Template.RegisterConfirmation.cshtml"
            );
        }

        private async Task SendEmailWithCallbackUrlAsync(
            string email,
            BaseEmailModel model,
            string subject,
            string view
        ) {
            await _smtpClient
                .To(email)
                .Subject(subject)
                .UsingTemplateFromEmbedded(
                    view,
                    model,
                    GetType().GetTypeInfo().Assembly)
                .SendAsync();
        }
    }
}