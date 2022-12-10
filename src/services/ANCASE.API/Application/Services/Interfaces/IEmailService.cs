using ANCASE.Core.DTOs;

namespace ANCASE.API.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDTO email);
    }
}
