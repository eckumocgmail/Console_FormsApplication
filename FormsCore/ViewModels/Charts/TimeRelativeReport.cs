using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TimeRelativeReport
{
    public int Granularity { get; set; } = 4;

    [SelectControl("bar,line,area,column")]
    public string ChartType = "bar";
    public DateTime BeginDate { get; set; }
    public DateTime EndDate
    {
        get
        {
            switch (Granularity)
            {
                case 1: return BeginDate.AddSeconds(1);
                case 2: return BeginDate.AddMinutes(1);
                case 3: return BeginDate.AddHours(1);
                case 4: return BeginDate.AddDays(1);
                case 5: return BeginDate.AddDays(7);
                case 6: return BeginDate.AddMonths(1);
                case 7: return BeginDate.AddYears(1);
            }
            throw new Exception("Не правильноен значение в свойстве гранулярность");
        }
    }
    public string Category { get; set; } = "Инф.ресурс";

    //types: Line, Column, bar
    public List<string> Indicators { get; set; } = new List<string> {
        "Кол-во функций", "Затраты на разработку"
    };




    /// <summary>
    /// Получение обьектов оценки по категории
    /// </summary>
    /// <returns></returns>
    public List<string> GetItems()
    {
        return new List<string>()
        {
            "ИЭМК","ОДЛИ"
        };
    }

    /// <summary>
    /// Получение подписей для шапки таблицы
    /// ( колонки: обьект оценки, для всех показателей [значение показателя, динамика за период] )
    /// </summary>
    /// <returns></returns>
    public List<string> GetColumns()
    {
        var columns = new List<string>() {
            Category
        };
        Indicators.ForEach(i =>
        {
            columns.Add(i);
            columns.Add("Динамика " + i);
        });
        columns.Add("Рейтинг");
        columns.Add("Рейтинг");
        return columns;
    }
}
