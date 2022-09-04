using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSource.Connection
{
    [ClassDescription("")]
    //"Data Source=myServerAddress;Catalog=myDataBase;ProtectionLevel=PktPrivacy;"
    public class OlapEncrypedConnection: OlapStandartConnection
    {
        public OlapEncrypedConnection():base()
        {

        }
    }
}
