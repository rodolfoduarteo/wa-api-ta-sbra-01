using Microsoft.AspNetCore.Mvc;
using wa_api_ta_azure_02.Data;
using wa_api_ta_azure_02.Models;
using wa_api_ta_azure_02.Services;
using wa_api_ta_azure_02.ViewModels;

namespace wa_api_ta_azure_02.Controllers
{
    public class PedidoController : ControllerBase
    {
         [HttpPost("CriarPedido")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CriarPedidoViewModel model,
            [FromServices] StoreDataContext context,
            [FromServices] NotificationService notificationService,
            [FromServices] MessageBusService messageBus,
            [FromServices] IConfiguration config)
        {
            try
            {
                var pedido = new Pedido
                {
                    Cliente = model.Cliente,
                    Data = DateTime.Now,
                    Numero = Guid.NewGuid().ToString().Substring(0, 8),
                    NomeProduto = model.NomeProduto,
                    Preco = model.Preco,
                };

                await context.Pedidos.AddAsync(pedido);
                await context.SaveChangesAsync();

                await notificationService.NotifyAsync("Loja Azure", $"[API] Olá {pedido.Cliente}, seu pedido {pedido.Numero} foi realizado com sucesso!");
                await messageBus.SendAsync(pedido);

                return Ok(pedido);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}