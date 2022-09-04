using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserInRoleAttribute: Attribute
{
    private readonly string[] _roles;

    public UserInRoleAttribute(string roles)
    {
        _roles = roles.Split(",");
    }

}