using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthorization.Views.Shared.Components;



[EntityIcon("apps")]
public class DropDownMenu: DropDown
{
    public List<ViewNode> Links { get; set; }
   
    public DropDownMenu() : base( )
    {
        Label = "eckumoc";
        //Links = new UserRolesService(new ApplicationDbContext()).GetUserRoleNavigation("Dev");
        Changed = false;
    }

    public DropDownMenu(string name, ILink item, TypeNode<ILink> parent) : base()
    {
        Label = name;
        Item = item;
        Changed = false;
    }
}

