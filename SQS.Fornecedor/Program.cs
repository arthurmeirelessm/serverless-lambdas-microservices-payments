using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Threading.Tasks;
using DotNetEnv;

internal class Program
{

    static string awsEndpoint = Environment.GetEnvironmentVariable("AWSENDPOINT") ?? string.Empty;
    private static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();

        // Connect to AWS SNS console using AWS SDK
        var client = new AmazonSQSClient(RegionEndpoint.USWest2);

        var request = new SendMessageRequest
        {
            QueueUrl = awsEndpoint,
            MessageBody = "peixe"
        };

        while (true)
        {
            var response = await client.SendMessageAsync(request);
        }
    }
}