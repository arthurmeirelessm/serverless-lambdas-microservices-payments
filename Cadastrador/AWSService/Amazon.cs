using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Cadastrador.Model;
using Amazon;

namespace Cadastrador.AWSService
{
    public static class Amazon
    {
        public static async Task SaveInDynamoAsync(this Pedido pedido)
        {
            var client = new AmazonDynamoDBClient(RegionEndpoint.USWest2);

            var context = new DynamoDBContext(client);

            await context.SaveAsync(pedido);
        }
    }
}
