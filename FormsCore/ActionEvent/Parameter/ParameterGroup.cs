using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthorization.ActionEvent.Property;

namespace UserAuthorization.ActionEvent.Parameter
{
    public class ParameterGroup : ConcurrentDictionary<string, SignleValueParameter>
    {
        public ParameterGroup( Type targetType,params SignleValueParameter[] parameters )
        {
            
        }
    }
}
