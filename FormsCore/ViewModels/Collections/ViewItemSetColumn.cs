using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ViewItemSetColumn : FormField
{
    [JsonIgnore()]
    public ViewItemSet ViewItemSet { get; set; }
    public List<object> GetValues(IEnumerable items)
    {
        List<object> values = new List<object>();
        foreach (var item in items)
        {
            object value = ReflectionService.GetValueFor(item, this.Name);
            values.Add(value);
        }
        return values;
    }
}