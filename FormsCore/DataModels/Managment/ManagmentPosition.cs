




using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Даталогическая модель сущности "Должность".
/// </summary>
 
[SearchTerms(nameof(Name) + "," + nameof(Description))]
[EntityLabel("Должность")]

public class ManagmentPosition : DimensionTable
{



    public virtual List<PositionFunction> PositionFunctions { get; set; }
}