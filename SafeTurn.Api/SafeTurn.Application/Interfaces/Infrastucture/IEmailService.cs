using System.Threading.Tasks;

namespace SafeTurn.Application.Interfaces.Infrastucture
{
    public interface IEmailService
    {
        Task SendRegisterConfirmationEmailAsync(string email, string name, string callbackUrl);
    }
}