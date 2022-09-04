using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public class Select: ViewItem
{
    public object Value { get; set; }
    public Dictionary<object, object> Options { get; set; }

    public Select() { }
}