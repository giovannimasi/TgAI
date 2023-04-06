using Microsoft.Extensions.Options;
using Telegram.Bot;
using TgAI.Settings;

namespace TgAI.Services;

public sealed class BotService
{
    public readonly TelegramBotClient _client;
    public readonly string _token;

    public BotService(IOptions<BotSettings> settings)
    {
        _client = new(settings.Value.Token);
        // TODO: find a better way to replace the token
        _client.SetWebhookAsync(settings.Value.WebhookUrl.Replace("{token}", settings.Value.Token));
        _token = settings.Value.Token;
    }
}
