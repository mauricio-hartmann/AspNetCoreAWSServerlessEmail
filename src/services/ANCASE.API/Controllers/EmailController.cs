using ANCASE.API.Application.Services.Interfaces;
using ANCASE.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ANCASE.API.Controllers
{
    [ApiController]
    [Route("email")]
    [Produces("application/json")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Realiza o envio de um email
        /// </summary>
        /// <param name="email">Dados do email</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /email
        ///     {
        ///         "subject": "Email test",
        ///         "to": [
        ///             "john@doe.com",
        ///             "johndoe@test.com"
        ///         ],
        ///         "body": "Email body"
        ///     }
        /// </remarks>
        /// <response code="200">Email enviado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailDTO email)
        {
            await _emailService.SendEmailAsync(email);

            return Ok();
        }
    }
}