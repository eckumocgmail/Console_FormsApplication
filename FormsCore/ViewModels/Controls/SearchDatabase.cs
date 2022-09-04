using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SearchDatabase: ViewItem
{
    public string Query { get; set; }
    public string Endpoint { get; set; }
    public string GetEndpointUrl()
    {
        return Endpoint;
    }
}