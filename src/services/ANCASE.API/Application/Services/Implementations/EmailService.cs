using ANCASE.API.Application.Services.Interfaces;
using ANCASE.Core.DTOs;
using ANCASE.MessageBus.Interfaces;

namespace ANCASE.API.Application.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IMessageBus _messageBus;

        public EmailService(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task SendEmailAsync(EmailDTO email) => await _messageBus.PublicAsync("EmailTopic", email);
    }
}
