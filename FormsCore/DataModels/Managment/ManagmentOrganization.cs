

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[EntityLabel("Организация")]
public class ManagmentOrganization : DimensionTable
{

    [Label("ИНН")]
    public string INN { get; set; }

    [Label("Юридический адрес")]
    public int JuristicalLocationID { get; set; }

    [Label("Юридический адрес")]
    public virtual ManagmentLocation JuristicalLocation { get; set; }


    [Label("Обособленные подразделения")]
    public List<ManagmentDepartment> ManagmentDepartments { get; set; }


    
}