using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
 
public class NavMenuService : INavMenuService
{
    private readonly ILogger<NavMenuService> _logger;
    private readonly NavMenuDbContext _context;

    public static int Counter = FormsHelper.AddWithOptions((services, configu) => {
        services.AddNavMenu();
        services.AddScoped<MaterialIconsService>();
        services.AddScoped<OpenIconsService>();
    });
    public NavMenuService(ILogger<NavMenuService> logger, NavMenuDbContext context)
    {
        _logger = logger;
        _context = context;
        if (GetNavLinks().Count() == 0)
        {
            foreach (var navLink in GetDefaultNavLinks())
            {
                _context.NavLinks.Add(navLink);
                _context.SaveChanges();
            }
        }
    }
    public IEnumerable<NavLink> GetNavLinks()
    {
        try 
        {
            return _context.NavLinks.ToArray();
        }
        catch
        {
            return GetDefaultNavLinks();
        }
        
    }

    public void CreateNavLink()
    {
        _context.NavLinks.Add(new global::NavLink() { Icon = "oi-home", Label = "Домашняя", Href = "/" });
        _context.SaveChanges();
    }

    public void Update(NavLink link)
    {
        _context.Update(link);
        _context.SaveChanges();
    }
    public void Remove(NavLink link)
    {
        _context.NavLinks.Remove(link);
        _context.SaveChanges();
    }

 

    public IEnumerable<NavLink> GetPageLinks(string uri)
    {
        _logger.LogInformation(uri);
        var navList = new List<NavLink>();
        string ns = "BlazorHospital.Client.Pages";
        var ids =
            uri.ReplaceAll("/", ".").ReplaceAll("\\", ".").Split(".").ToList().Where(s => string.IsNullOrEmpty(s) == false).Select(s => s.ToCapitalStyle()).ToList();
        ids.ForEach(id => ns += "." + id);
        _logger.LogInformation($"Namespace: {ns}");
        foreach (var page in Assembly.GetCallingAssembly().GetPages(ns))
        {
            var attrs = page.GetAttrs();
            if (attrs.ContainsKey("RouteAttribute"))
            {
                navList.Add(new NavLink() { Icon = "home", Label = page.GetName(), Href = attrs["RouteAttribute"] });
            }
            if (attrs.ContainsKey("Route"))
            {
                navList.Add(new NavLink() { Icon = "home", Label = page.GetName(), Href = attrs["Route"] });
            }

        };
        return navList.ToArray();
    }

    public IEnumerable<NavLink> GetDefaultNavLinks()
    {
        return new List<NavLink> {
            new NavLink(){ Icon="home", Label="Домашняя", Href="/" },
            new NavLink(){ Icon="plus", Label="Версии", Href="/counter" },
            new NavLink(){ Icon="list-rich", Label="Редактор форм", Href="/input-forms" },
            new NavLink(){ Icon="person", Label="Редактор меню", Href="/nav-menu" }

        };
    }


    public Task OnNavTreeInit(object evt)
    {
        return Task.Run(() =>
        {
            _logger.LogInformation("OnNavTreeInit(evt)");
            //NavTree tree = (NavTree)evt;
            //tree.Reset(GetPageLinks());
        });
    }

    public IEnumerable<NavLink> GetPageLinks()
    {
        throw new System.NotImplementedException();
    }
}

public interface INavMenuService
{

    public Task OnNavTreeInit(object evt);
    public IEnumerable<NavLink> GetPageLinks(string uri);
    public IEnumerable<NavLink> GetPageLinks();
    public IEnumerable<NavLink> GetNavLinks();
    public void Update(NavLink link);
    public void Remove(NavLink link);
    public void CreateNavLink();

}
public class NavMenuDbContext : DbContext
{
    public DbSet<NavLink> NavLinks { get; set; }
    public NavMenuDbContext(DbContextOptions<NavMenuDbContext> options) : base(options) { }
}
public static class NavMenuServiceExtension
{
    public static IServiceCollection AddNavMenu(this IServiceCollection services)
    {
        services.AddOpenIcons();
        services.AddScoped<INavMenuService, NavMenuService>();
        services.AddDbContext<NavMenuDbContext>(options => options.UseInMemoryDatabase(nameof(NavMenuDbContext)));
        return services;
    }
}
