using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSource.Connection
{
    //"Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;"
    [ClassDescription("")]
    public class SqlServerTrustedConnection : SqlServerStandardConnection
    {
        public SqlServerTrustedConnection() : base() { }
    }
}
