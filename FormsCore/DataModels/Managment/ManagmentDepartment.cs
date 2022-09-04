


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Даталогическая модель сущности "Подразделение".
/// </summary>
[EntityLabel("Подразделение")]
[SearchTerms(nameof(Name) + "," + nameof(Description))]
public class ManagmentDepartment : NamedObject
{

    [SelectDataDictionary("ManagmentDepartmentTypes,Name")]
    public string Type { get; set; }
    public ManagmentDepartment()
    {
        Employees = new List<ManagmentEmployee>();
    }

    [Label("Организация")]
    public int OrganizationID { get; set; } = 1;

    [Label("Организация")]
    public virtual ManagmentOrganization Organization { get; set; }


    [Label("Сотрудники")]
    public virtual List<ManagmentEmployee> Employees { get; set; }





}