using Smtp.Models;

namespace Smtp.Services;

public interface ISmppService
{
    Task<BaseResponse> Send(SendSmsDto dto);
}