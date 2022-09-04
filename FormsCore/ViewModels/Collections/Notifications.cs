using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Notifications: ViewItem
{
    public List<NotificationMessage> Messages { get; set; } = new List<NotificationMessage>();
    public NotificationMessage[] GetMessages( )
    {        
        var res = Messages.ToArray();
        Messages.Clear();
        return res;
    }


    public void Add(NotificationMessage message)
    {
 
        Messages.Add(message);
        Changed = true;
    }

}

