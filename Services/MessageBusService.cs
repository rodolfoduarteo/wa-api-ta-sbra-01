using System.Text.Json;
using Azure.Messaging.ServiceBus;
using wa_api_ta_azure_02.Models;

namespace wa_api_ta_azure_02.Services
{
    public class MessageBusService
    {
        private readonly IConfiguration _configuration;

        public MessageBusService(IConfiguration configuration) => _configuration = configuration;

        public async Task SendAsync(Pedido pedido)
        {
            await SendAsync(pedido, "pedidos");
        }
        
        public async Task SendAsync(Pedido pedido, string queue)
        {
            var connectionString = _configuration["ServiceBusConnectionString"];
            await using var client = new ServiceBusClient(connectionString);

            var sender = client.CreateSender(queue);
            var json = JsonSerializer.Serialize(pedido);
            var message = new ServiceBusMessage(json);

            await sender.SendMessageAsync(message);
        }
    }
}