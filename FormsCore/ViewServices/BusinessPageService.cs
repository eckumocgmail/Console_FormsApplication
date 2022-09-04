using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// Расширение для разработчиков сайтов
/// </summary>
public static class BusinessPageServiceExtensions
{
    public static IServiceCollection AddBusinessPages( this IServiceCollection services)
    {
        WriteLine("Регистрация сервиса, динамического проектирования");
        services.AddScoped<IBusinessPageService, BusinessPageService>();
        return services;
    }
}


/// <summary>
/// Функции разработки сайтов
/// </summary>
public interface IBusinessPageService 
{

    /// <summary>
    /// Регистрация новой странице и переход в режим контруктора
    /// </summary>    
    public void CreateBusinessPage(string location);

    /// <summary>
    /// Проверка наличия страницы по заданному URL
    /// </summary>
    public bool HasPageForLocation(string location);


    /// <summary>
    /// Формирование элементов управления страницы 
    /// </summary>
    public InputFormModel GetFormForLocation(string location);
}





/// <summary>
/// Предоставляет доступ разработанным пользователем страницам
/// </summary>
public class BusinessPageService : IBusinessPageService
{
    private readonly InputFormDbContext _forms;

    public BusinessPageService(InputFormDbContext forms) {
        _forms = forms;
    }


    /// <summary>
    /// Регистрация новой странице и переход в режим контруктора
    /// </summary>  
    public void CreateBusinessPage(string location)
    {

        WriteLine("Регистрация новой странице и переход в режим контруктора");
        var form = new InputFormModel();
        _forms.InputFormModels.Add(form);
        _forms.SaveChanges();
        
        _forms.BusinessPageModel.Add(new BusinessPageModel()
        {
            Form = form
        });
        _forms.SaveChanges();
    }


    /// <summary>
    /// Проверка наличия страницы по заданному URL
    /// </summary>    
    public InputFormModel GetFormForLocation(string location)
    {
        WriteLine($"Проверка наличия страницы по заданному URL: {location}"); ;
        var page = _forms.BusinessPageModel
            .Include(page=>page.Form)
            .Where(p => p.Name == location).FirstOrDefault();
        if( page == null)
        {
            return page.Form;
        }
        else
        {
            return null;
        }

        
    }



    /// <summary>
    /// Проверка наличия страницы по заданному URL
    /// </summary>   
    public bool HasPageForLocation(string location)
    {
        return (location == "/forms/registration");
    }
}
