using Newtonsoft.Json.Linq;
using System.Collections.Generic;

[EntityLabel("Диаграмма")]
[EntityIcon("line_chart")]
public class Chart: ViewItem
{

    [Label("Заголовок")]
    public string Title { get => Get<string>("Title"); set => Set<string>("Title", value); }

    [Label("Тип диграммы")]
    [SelectControl("Bar,Core,Line,Org,Column")]
    public string Type { get => Get<string>("Type"); set => Set<string>("Type", value); }


    [Label("Ряды")]
    public dynamic Series { get; set; }

    /// <summary>
    /// Модель рядов 
    /// [
    ///     [{name: string, data: number[] }]
    /// ]
    /// </summary>
    /// <param name="series"></param>
    public void SetSeries(NamedSeriesArray[] series)
    {
        Series = series;
    }


    [Label("Ось Y")]
    public string Yaxis { get; set; } = "";

    public Chart()
    {
        Title = "Новая диаграмма";
        Type = "Core";
        Series = new object[] {
          
        };
    }


    /// <summary>
    /// Выгрузка в модели в json
    /// </summary>
    /// <returns></returns>
    public string GetSeriesJson()
    {        
        return JObject.FromObject(new { dataset = this.Series }).ToString() + ".dataset";
    }


    /// <summary>
    /// Используется для преобразования структуры данных в модель диаграммы
    /// </summary>
    /// <param name="dataset"></param>
    /// <param name="nameExpression"></param>
    /// <param name="dataExpression"></param>
    /// <returns></returns>
    public object MapSeries( JArray dataset, string nameExpression, string dataExpression)
    {
        var result = new List<object>();
        foreach(var p in dataset)
        {
            string name = p[nameExpression].Value<string>();
            List<object> data = new List<object>();
            foreach(var datakey in dataExpression.Split(","))
            {
                data.Add(p[datakey].Value<object>());
            }
            result.Add(new { 
                name=name,
                data=data.ToArray()
            });
        }
        return result;
    }
}