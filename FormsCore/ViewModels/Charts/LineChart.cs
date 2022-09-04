using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LineChart{

    public string Title { get; set; } = "Динамика";
    public string TimeUnit { get; set; } = "Год";
    public List<string> Indicators { get; set; } = new List<string>();
    public List<string> Times { get; set; } = new List<string>();
    public float[][] Values { get; set; }


    public object ToDataTable() {
        var table = new List<object>();
        var header = new List<string>(new string[] { TimeUnit }).Concat(new List<string>(this.Indicators));
        table.Add(header);
        int i = 0;
        foreach(var time in Times)
        {
            var line = new List<object>() { time };
            foreach(var p in Values[i])
            {
                line.Add(p);
            }
            table.Add(line);
        }
        return JObject.FromObject(new { data = table } )["data"];
    }

}
 
 