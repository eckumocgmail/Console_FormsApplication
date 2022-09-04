using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NavBar: ViewItem, ILink
{
    public string Brand { get; set; }
    
    public string Icon { get; set; }
    public string Label { get; set; }
    public string Href { get; set; }
    public bool IsActive { get; set; }
    public object Item { get; set; }
    public string Tooltip { get; set; }

    public Link Active { get; set; }
    public List<ILink> ChildLinks { get; set; }


    public NavBar()
    {
        Brand = "EckUmOC";
        Item = new FlexContainer();


        Init();
        Changed = false;
    }


    public void AddLink(ILink link)
    {
        if(ChildLinks == null)
        {
            ChildLinks = new List<ILink>();
        }
        ChildLinks.Add(link);
    }

}