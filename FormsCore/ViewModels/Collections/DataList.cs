
using ApplicationDb.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DataList: ViewItem
{
    public Type Type { get; set; }
    public List<object> Items { get; set; }

    public JArray Dataset { get; set; }


    [Label("Заголовок")]
    public string Title { get => Get<string>("Title"); set => Set<string>("Title", value); }
 
 
    public ConcurrentDictionary<string, Action<List>> Actions { get; set; } = new ConcurrentDictionary<string, Action<List>>();

    public Dictionary<string, string> Bindings { get; set; }


    public DataList() : base()
    {

        //Dataset = new OdbcDataSource().CleverExecute("select * from Persons").DataSet;
        Selectable = true;       
        Title = "List"; 
        Bindings = new Dictionary<string, string>() {
            { "Title", "Tel" }
        };
    }
     
}