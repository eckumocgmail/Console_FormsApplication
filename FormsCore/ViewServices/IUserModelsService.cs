using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUserModelsService
{
    public int RegistrateModel(object instance)
    {
        return instance.GetHashCode();
    }
}