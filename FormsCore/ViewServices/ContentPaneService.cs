using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

/// <summary>
/// Определяет мектоды позиционирования блока исходя из собственных свойств
/// </summary>
public interface IContentPaneService
{

    /// <summary>
    /// Переместить к правой границе
    /// </summary>
    /// <param name="pane"></param>
    public void MoveToRightBorder(Pane pane);


    /// <summary>
    /// Переместить к верхней границе
    /// </summary>
    /// <param name="pane"></param>
    public void MoveToTopBorder(Pane pane);

    /// <summary>
    /// Переместить к левой границе
    /// </summary>
    /// <param name="pane"></param>
    public void MoveToLeftBorder(Pane pane);


    /// <summary>
    /// Переместить к левой границе
    /// </summary>
    /// <param name="pane"></param>
    public void MoveToBottomBorder(Pane pane);

    /// <summary>
    /// Установить абсолютное значение ширины
    /// </summary>
    /// <param name="pane"></param>
    public void SetAbsolutelyWidth(Pane pane, int px);

    /// <summary>
    /// Установить абсолютное значение высоты
    /// </summary>
    /// <param name="pane"></param>
    public void SetAbsolutelyHeight(Pane pane, int px);

    /// <summary>
    /// Установить относительное значение ширины в процентах
    /// </summary>
    /// <param name="pane"></param>
    public void SetRelativeWidth(Pane pane, int px);

    /// <summary>
    /// Установить абсолютное значение высоты в процентах
    /// </summary>
    /// <param name="pane"></param>
    public void SetRelativeHeight(Pane pane, int px);


}





public class ContentPaneService : IContentPaneService

{
    public static int Counter = FormsHelper.AddScopedConfiguration<IContentPaneService, ContentPaneService>();

    public void MoveToBottomBorder(Pane pane)
    {
        throw new NotImplementedException();
    }

    public void MoveToLeftBorder(Pane pane)
    {
        throw new NotImplementedException();
    }

    public void MoveToRightBorder(Pane pane)
    {
        throw new NotImplementedException();
    }

    public void MoveToTopBorder(Pane pane)
    {
        throw new NotImplementedException();
    }

    public void SetAbsolutelyHeight(Pane pane, int px)
    {
        throw new NotImplementedException();
    }

    public void SetAbsolutelyWidth(Pane pane, int px)
    {
        throw new NotImplementedException();
    }

    public void SetRelativeHeight(Pane pane, int px)
    {
        throw new NotImplementedException();
    }

    public void SetRelativeWidth(Pane pane, int px)
    {
        throw new NotImplementedException();
    }
}



 


public static class ontentPaneExtension
{
    public static IServiceCollection AddContentPane(this IServiceCollection services)
    {
        services.AddScoped<IContentPaneService, ContentPaneService>();
        return services;
    }
}
