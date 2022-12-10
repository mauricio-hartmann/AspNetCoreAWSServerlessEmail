using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace EmailFunction;

public class Function
{
    public void FunctionHandler(SNSEvent snsEvent)
    {
        foreach (var record in snsEvent.Records)
        {
            var snsRecord = record.Sns;
            LambdaLogger.Log(snsRecord.Message);
        }
    }
}
