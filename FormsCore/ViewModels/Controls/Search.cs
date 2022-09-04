using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Search: ViewItem
{
    public string Query { get; set; }

    [JsonIgnore()]
    public Func<Search, object> AtInput { get; set; }

    [JsonIgnore()]
    public Func<Search, object> AtSearch { get; set; }

    public Search()
    {
        Changed = false;    
    }

    public object OnInput(string query)
    {
        this.Query = query;
        if (AtInput != null)
        {
            return AtInput(this);
        }
        return new { };
    }

    public object OnSearch(string query )
    {
        this.Query = query;
        if (AtSearch != null)
        {
            return AtSearch(this);
        }
        return new { };
    }


}