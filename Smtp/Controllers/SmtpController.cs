using Microsoft.AspNetCore.Mvc;
using Smtp.Models;
using Smtp.Services;

namespace Smtp.Controllers;

[ApiController]
[Route("api/smtp")]
public class SmtpController : ControllerBase
{
    private readonly ISmppService _smppService;

    public SmtpController(ISmppService smppService)
    {
        _smppService = smppService;
    }
    [HttpPost]
    public async Task<BaseResponse> Send(SendSmsDto dto)
    {
        return await _smppService.Send(dto);
    }
}