using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ANCASE.MessageBus.Interfaces;
using System.Text.Json;

namespace ANCASE.MessageBus.AWS
{
    internal class AwsMessageBus : IMessageBus
    {
        private AmazonSimpleNotificationServiceClient _messageBus;
        private ListTopicsResponse _topics;

        public AwsMessageBus(string accessKey, string secretKey)
        {
            _messageBus = new AmazonSimpleNotificationServiceClient(accessKey, secretKey);
        }

        public async Task PublicAsync(string destin, object data)
        {
            var serializedData = JsonSerializer.Serialize(data);

            if(_topics is null)
                _topics = await _messageBus.ListTopicsAsync();

            var topic = _topics.Topics.FirstOrDefault(x => x.TopicArn.EndsWith(destin));
            await _messageBus.PublishAsync(topic?.TopicArn, serializedData);
        }
    }
}
