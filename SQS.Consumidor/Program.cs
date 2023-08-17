using Amazon.SQS.Model;
using Amazon.SQS;
using Amazon;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using DotNetEnv;

internal class Program
{
    static string awsEndpoint = Environment.GetEnvironmentVariable("AWSENDPOINT") ?? string.Empty;
    private static async Task Main(string[] args)
    {
        
        DotNetEnv.Env.Load();

        var client = new AmazonSQSClient(RegionEndpoint.USWest2);

        var request = new ReceiveMessageRequest
        {
            QueueUrl = awsEndpoint
        };

        // EX: As long as there are messages in the queue the client will be called
        while (true)
        {
            var response = await client.ReceiveMessageAsync(request);

            // EX: Doing for each to access queue consumption response
            foreach (var message in response.Messages)
            {
                // EX: While messages such as catapimbas or carambola are in the file, they will be deleted
                List<string> list = new List<string> { "catapimbas", "carambolas" };
                while (list.Contains(message.Body))
                {
                    Console.WriteLine(message.Body);
                    await client.DeleteMessageAsync(awsEndpoint, message.ReceiptHandle);
                }
            }
        }
    }
}