using Cadastrador.Model;
using Microsoft.AspNetCore.Mvc;
using Cadastrador.AWSService;

namespace Cadastrador.Controllers;

[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    // GET api/values
    [HttpPost(Name = "pedido")]

    public async Task PostAsync([FromBody] Pedido pedido) => await pedido.SaveInDynamoAsync();
}