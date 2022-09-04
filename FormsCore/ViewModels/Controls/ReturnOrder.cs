  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
public class ReturnOrder: StructuredCollection 
{
    public string foreignKey;
    public int targetId;
    public string selfKey;
    public string bindingTableTypeName;
    public Type bindingTableType;

    public string NextUrl { get; set; } = null;




    public string SearchQuery { get=>Get<string>("SearchQuery"); set=>Set<string>("SearchQuery",value); }
    public List<object> Available { get => Get<List<object>>("Available"); set => Set<List<object>>("Available", value); }
    public List<object> Comfirmed { get => Get<List<object>>("Comfirmed"); set => Set<List<object>>("Comfirmed", value); }

    public int CurrentPage { get => Get<int>("CurrentPage"); set => Set<int>("CurrentPage", value); }
    public int TotalPages { get => Get<int>("TotalPages"); set => Set<int>("TotalPages", value); }
    public int PageSize { get => Get<int>("PageSize"); set => Set<int>("PageSize", value); }


    



    public ReturnOrder()
    {
        Searchable = true;
        SearchQuery = "";
        CurrentPage = 1;
        TotalPages = 1;
        PageSize = 10;
        Available = new List<object>();
        Comfirmed = new List<object>();
    }

    public int PrevPage()
    {
        return CurrentPage - 1;
    }


    public int NextPage()
    {
        return CurrentPage + 1;
    }
}
 