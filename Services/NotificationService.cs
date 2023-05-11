using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using wa_api_ta_azure_02.ViewModels;

namespace wa_api_ta_azure_02.Services
{
    public class NotificationService
    {
        private readonly IConfiguration _configuration;
        public NotificationService(IConfiguration configuration) => _configuration = configuration;

        public async Task NotifyAsync(string cliente, string mensagem)
        {
            var notification = new DiscordNotificationModel(
                _configuration["DiscordWebHookUrl"],
                mensagem,
                cliente);

            var httpClient = new HttpClient();
            var data = JsonSerializer.Serialize(notification, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync(notification.WebHookUrl, content);
        }
    }
}