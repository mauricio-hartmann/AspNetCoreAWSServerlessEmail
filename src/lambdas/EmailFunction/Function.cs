using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using ANCASE.Core.DTOs;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EmailFunction;

public class Function
{
    public async Task FunctionHandlerAsync(SNSEvent snsEvent)
    {
        foreach (var record in snsEvent.Records)
        {
            try
            {
                var snsRecord = record.Sns;
                EmailDTO email = JsonSerializer.Deserialize<EmailDTO>(snsRecord.Message);

                var destination = new Destination(email.To.ToList());
                var body = new Body(new Content(email.Body));
                var emailMessage = new Message(new Content(email.Subject), body);
                var emailRequest = new SendEmailRequest("mauricio.auditore@gmail.com", destination, emailMessage);
                
                var emailClient = new AmazonSimpleEmailServiceClient();
                await emailClient.SendEmailAsync(emailRequest);

                LambdaLogger.Log($"Email enviado: {snsRecord.Message}");
            }
            catch (Exception e)
            {
                LambdaLogger.Log($"Erro ao enviar email: {e.Message}");
            }
        }
    }
}
