using System.Net;

namespace Smtp.Models;

public class BaseResponse
{
    public BaseResponse() { }
    public BaseResponse(HttpStatusCode statusCode, string defaultMessage)
    {
        StatusCode = (int)statusCode;
        Message = defaultMessage;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    public static BaseResponse Ok(string message = "Success") => new BaseResponse(HttpStatusCode.OK, message);

    public static BaseResponse Error(string message = "Оишбка при отправки смс!") => new BaseResponse(HttpStatusCode.BadRequest, message);
}