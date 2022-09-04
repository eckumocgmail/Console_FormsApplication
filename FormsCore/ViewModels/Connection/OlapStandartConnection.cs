using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ClassDescription("Data Source=myServerAddress;Catalog=myDataBase;")]
public class OlapStandartConnection : MyValidatableObject
{

    [Alias("Data Source")]
    [NotNullNotEmpty("Необходимо ввести наименование источника")]
    public string DataSource { get; set; }


    [Alias("Data Source")]
    [NotNullNotEmpty("Необходимо ввести наименование источника")]
    public string Catalog { get; set; }



    public OlapStandartConnection()
    {

    }

}