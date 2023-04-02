using Microsoft.Extensions.Options;
using Telegram.Bot;
using TgAI.Settings;

namespace TgAI.Services;

public sealed class BotService
{
    public readonly TelegramBotClient _client;

    public BotService(IOptions<BotSettings> settings) =>
        _client = new(settings.Value.Token);
}
