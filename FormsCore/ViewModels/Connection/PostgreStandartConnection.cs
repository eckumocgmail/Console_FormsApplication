using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSource.Connection
{
    [ClassDescription("")]
    //"Driver={PostgreSQL};Server=IP address;Port=5432;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"
    public class PostgreStandartConnection: MyValidatableObject
    {
        public PostgreStandartConnection():base()
        {
        }
    }
}
