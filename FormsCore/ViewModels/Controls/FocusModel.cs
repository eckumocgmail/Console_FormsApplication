using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FocusModel: ViewItem
{
    public ConcurrentDictionary<int, ViewItem> NowInFocus { get; set; } = new ConcurrentDictionary<int, ViewItem>();
    public FocusModel() { 
    }

    public void Add(ViewItem item)
    {
        NowInFocus[item.GetHashCode()] = item;
    }
    public void Remove(ViewItem item)
    {
 
        NowInFocus.TryRemove(item.GetHashCode(),out item);
    }
}