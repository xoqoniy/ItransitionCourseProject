using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Course_Project.Shared.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long? UserId => int.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;
    public static string UserRole => HttpContext?.User?.FindFirst("role")?.Value;

    private static int _tempUserId;
}