using System;
using System.Collections.Generic;
using System.Linq;

public class Router: ViewItem
{
    public string State { get; set; }
    public ViewItem Active { get; set; }
    public ILink Config { get; set; }


    public Router( )
    {
        
    }


    public Router(RouterConfig Config) {
       
    }

    


    public void Navigate(string path)
    {
        if (path.StartsWith("./"))
        {
            ILink proute = Config;
            foreach (string name in path.Substring(2).Split("/"))
            {
                proute = (from p in proute.ChildLinks where Match(p.Href, name) select p).SingleOrDefault();
                if (proute == null)
                {
                    throw new Exception("Не удалось найти страницу: "+ path+", т.к. "+name+" не зарегистрирован");
                }
            }
            State = path;
            Active = (ViewItem)proute.Item;
        }
    }

    

    private bool Match(string path, string name)
    {
        return path=="**" || path.ToLower() == name.ToLower();
    }
}