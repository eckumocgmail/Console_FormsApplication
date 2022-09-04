using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SelectableListItem<T>
{
    public T Item { get; set; }
    public string Label { get; set; }
    public string Badge { get; set; }
    public bool Selected { get; set; }
    public bool Checked { get; set; }
}

public class SelectableListItem : SelectableListItem<object> 
{ }



public class SharedListService
{
}

