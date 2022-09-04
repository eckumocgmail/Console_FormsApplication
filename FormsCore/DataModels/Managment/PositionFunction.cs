



using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System.Collections.Generic;
/// <summary>
/// Должностные обязанности
/// </summary>
[EntityLabel("Должностные обязанности")]
[SearchTerms(nameof(Name) + ",Description,{{Position.Name}}")]
public class PositionFunction : DimensionTable
{

    public PositionFunction()
    {
        FunctionSkills = new List<FunctionSkills>();
    }

    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; }
    public virtual ManagmentPosition Position { get; set; }

    public virtual List<FunctionSkills> FunctionSkills { get; set; }



}