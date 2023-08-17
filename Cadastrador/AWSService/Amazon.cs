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
            //logic to insert user according to the body of the file "\ResponseExamples\ResponseRequest"
            pedido.id = Guid.NewGuid().ToString();

            pedido.DataDeCriacao = DateTime.Now;

            var client = new AmazonDynamoDBClient(RegionEndpoint.USWest2);

            var context = new DynamoDBContext(client);

            await context.SaveAsync(pedido);
        }
    }
}
