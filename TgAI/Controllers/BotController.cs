using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgAI.Services;

namespace TgAI.Controllers;

[ApiController]
[Route("v1/bot")]
public sealed class BotController : Controller
{
    private readonly ITelegramBotClient _botClient;
    private readonly string _token;

    public BotController(BotService botService)
    {
        _botClient = botService._client;
        _token = botService._token;
    }

    [HttpPost("{token}")]
    public IActionResult NewMessage([FromRoute] string token, [FromBody] Update update)
    {
        if (token != _token) return Unauthorized();

        _botClient.SendTextMessageAsync(update.Message!.Chat, "PONG!");
        return Ok();
    }
}
