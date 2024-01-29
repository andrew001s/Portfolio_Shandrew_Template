using ShandrewPage.Models;
namespace ShandrewPage.Conections
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
