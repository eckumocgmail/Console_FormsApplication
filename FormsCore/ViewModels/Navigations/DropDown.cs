using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthorization.Views.Shared.Components;



[EntityIcon("apps")]
public class DropDown: Link
{
    public List<ViewNode> Links { get; set; }
   
    public DropDown() : base( )
    {
        Label = "eckumoc";
        //Links = new UserRolesService(new ApplicationDbContext()).GetUserRoleNavigation("Dev");
        Changed = false;
    }

    public DropDown(string name, ILink item, TypeNode<ILink> parent) : base()
    {
        Label = name;
        Item = item;
        Changed = false;
    }
}

