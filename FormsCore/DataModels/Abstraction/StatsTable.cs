using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
/// <summary>
/// Сущность реализующая данный клас хранит 
/// колличественные характеристики выполнения 
/// бизнес функций обьектами информационного взаимодействия
/// за оределённый промежуток времени, заданный 
/// свойствами [Begin, EndDate).
/// 
/// Важно! 
/// Обратите внимание что конечный точка EndDate исключена из промежутка.
/// </summary>
public class StatsTable
{
    [Label("Начало периода")]
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [Label("Начало периода")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }


    public List<string> GetDimensions()
    {
        List<string> dims = new List<string>();
        foreach (var nav in Attrs.GetNavigation(this.GetType()))
        {
            var propertyType = this.GetType().GetProperty(nav.Name).GetType();
            if (Typing.HasBaseType(propertyType, typeof(DimensionTable)))
            {
                dims.Add(nav.Name);
            }
        }
        return dims;
    }



    public List<string> GetIndicators()
    {
        return (from p in GetType().GetProperties() where Typing.IsNumber(p) select p.Name).ToList();
    }

}
