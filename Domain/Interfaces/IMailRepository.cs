using ProjectOs.Domain.Models;
using System.Threading.Tasks;

namespace ProjectOs.Domain.Interface
{
    public interface IMailRepository
    {
        Task SendEmailAsync(SendEmail sendEmail);
    }
}
