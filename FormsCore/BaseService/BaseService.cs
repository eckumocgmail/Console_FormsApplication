 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public abstract class BaseService  
{
    public BaseService()
    {
        //Info("");
    }
    public virtual void Error(Exception ex)
    {
        Console.WriteLine($"[Error][{GetType().GetTypeName()}]: {ex.GetType().Name}");
        Console.WriteLine($"[Error][{GetType().GetTypeName()}]: {ex.Message}");
        Console.WriteLine($"[Error][{GetType().GetTypeName()}]: {ex.StackTrace}");
    }
    public virtual void Info(object item)
    {        
        if(item!=null && item.GetType().IsArray)
        {
            foreach(var next in (dynamic)item)
            {
                Info(next);
            }
        }
        else
        {
            Console.WriteLine($"[Info][{GetType().GetTypeName()}]: {item}");
        }
        //Thread.Sleep(100);
    }
}
