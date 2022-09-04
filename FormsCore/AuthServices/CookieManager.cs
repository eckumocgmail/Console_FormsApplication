using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

[EntityLabel("Управление куки")]
[Description("Управляет заголовками средствами NetCore")]
public class CookieManager
{
    public static int Counter = FormsHelper.Add((services)=> {
        services.AddHttpContextAccessor();
        services.AddScoped<CookieManager>();
    });


    private readonly IHttpContextAccessor _accessor;
    private readonly ConcurrentDictionary<string, string> _cookies;

    public CookieManager(IHttpContextAccessor accessor)
    {
        _cookies = new ConcurrentDictionary<string, string>();
        _accessor = accessor;
        if(_accessor.HttpContext != null)
        {
            foreach (var cookie in _accessor.HttpContext.Request.Cookies)
            {
                _cookies[cookie.Key] = cookie.Value;
            }
        }
        
    }

    public void SetCookie(string key, string value)
    {
        if (_accessor.HttpContext.Response.HasStarted == false)
        {
            _accessor.HttpContext.Response.Cookies.Append(key, value);
            _cookies[key] = value;
        }
    }

    public string GetCookie(string key)
    {
        if (_cookies.ContainsKey(key))
            return _cookies[key];
        else return null;
    }

    public void RemoveCookie(string cookies)
    {
        _accessor.HttpContext.Response.Cookies.Delete(cookies);
    }
}