using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Модель представления постраничной навигации, 
/// при изменении текущей страницы или размера страницы
/// выполняется метод OnPageChanged.
/// </summary>
public class Pagination: ViewItem
{
    public int TotalPages { get; set; } = 1;
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
        
    public int PrevPage()
    {
        return CurrentPage - 1;
    }

    public int NextPage()
    {
        return CurrentPage + 1;
    }

    public void UpdatePages(int TotalResults)
    {
        TotalPages = (TotalResults % PageSize == 0) ? TotalResults / PageSize : (int)Math.Floor((decimal)(TotalResults / PageSize));
    }

    public Pagination() {
        TotalPages = 10;
        CurrentPage = 3;

    }


}
