using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSource.Connection
{


    [ClassDescription("")]
    public class PostgreSslConnection : PostgreStandartConnection
    {
        public PostgreSslConnection() : base()//"Driver={PostgreSQL ANSI};Server=IP address;Port=5432;Database=myDataBase;Uid=myUsername;Pwd=myPassword;sslmode=require;")
        {

        }
    }
}
