using ActionEvent;
using Microsoft.AspNetCore.Http;
using System;


public class IRobotAuthService 
{
    private const string COOKIE_KEY = "SesionID";
    private readonly ITokenProvider tokenProvider;
    private readonly CookieManager _cookiesManager;
    private readonly ISessionManager _application;
    private readonly IHttpContextAccessor _http;


    public IRobotAuthService(
        CookieManager cookiesManager, 
        ISessionManager application,
        ITokenProvider tp,
        IHttpContextAccessor http )
    {
        tokenProvider = tp;
        _cookiesManager = cookiesManager;
        _application = application;
        _http = http;      
    }



    public ISessionManager GetSessionManager()
    {
        return _application;
    }


    public ViewContext GetRoot()
    {
        return GetSession().GetRoot();
    }


    private string GetIpAddress()
    {
        return _http.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }


    public SessionContext GetSession()
    {
        string ip = GetIpAddress();
        string id = Identify();
        SessionContext session = _application.GetById( id );
        if( session.ip == null)
        {
            session.ip = ip;
        }
        else
        {
            if( session.ip != ip)
            {
                //throw new Exception($"IP-адрес изменился c {session.ip} на {ip}"); 
                Writing.ToConsole($"IP-адрес изменился c {session.ip} на {ip}");
            }
        }
        return session;
    }


    public string Identify()
    {
        string sessionId = tokenProvider.Get();
        if(string.IsNullOrEmpty(sessionId)==false)
        {
            return sessionId;
        }
        else
        {
            string id = CreateId();
            tokenProvider.Set(id);
            return id;
        }
    }


    private string CreateId()
    {
        string id = CreateRandomId();
        while( _application.ContainsKey(id))
        {
            id = CreateRandomId();
        }
        return id;
    }


    private string CreateRandomId()
    {
        string id = "";         
        while (id.Length != 10)
        {
            id+=Math.Floor(SessionContext.GetRandom().NextDouble() * 10).ToString();
        }
        return id;
    }

    public void OnSignout()
    {
        string cookies = _cookiesManager.GetCookie(COOKIE_KEY);
        _application.Invalidate(cookies);
        _cookiesManager.RemoveCookie(cookies);
    }
}
