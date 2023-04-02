﻿using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgAI.Services;

namespace TgAI.Controllers;

[ApiController]
[Route("v1/bot")]
public sealed class BotController : Controller
{
    private readonly ITelegramBotClient _botClient;

    public BotController(BotService botService) =>
        _botClient = botService._client;

    [HttpPost("/{token}")]
    public IActionResult NewMessage([FromRoute] string _, [FromBody] Update update)
    {
        _botClient.SendTextMessageAsync(update.Message!.Chat, "PONG!");
        return Ok();
    }
}
