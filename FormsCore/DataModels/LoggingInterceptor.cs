using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreConstructorAngular.Data
{
    public class LoggingInterceptor: DbCommandInterceptor

    {
        public override 
            InterceptionResult<DbDataReader> ReaderExecuting(
                DbCommand command, 
                CommandEventData eventData, 
                InterceptionResult<DbDataReader> result)
        {
            Writing.ToConsole("\n"+command.CommandText+"\n\n");

            return result;
        }
    }
}
