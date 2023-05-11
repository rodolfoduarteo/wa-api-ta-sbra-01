using System.Text.Json.Serialization;

namespace wa_api_ta_azure_02.ViewModels
{
    public class DiscordNotificationModel
    {
        public DiscordNotificationModel(
            string webHookUrl,
            string content,
            string username = "store.bot",
            string avatarUrl = "https://discordbotlist.com/icon.png")
        {
            Content = content;
            Username = username;
            AvatarUrl = avatarUrl;
            WebHookUrl = webHookUrl;
        }

        [JsonPropertyName("content")] 
        public string Content { get; set; }

        [JsonPropertyName("username")] 
        public string Username { get; set; }

        [JsonPropertyName("avatar_url")] 
        public string AvatarUrl { get; set; }

        [JsonIgnore] 
        public string WebHookUrl { get; set; }
    }
}
