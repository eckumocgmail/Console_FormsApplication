using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

public class ViewItemSet: ViewItem
{
    public string View { get; set; } = "Tabs";

    [JsonIgnore()]
    public List<ViewItemSetColumn> Columns { get; set; } = new List<ViewItemSetColumn>();

    [JsonIgnore()]
    public List<Form> Items { get; set; } = new List<Form>();
    

    public ViewItemSet() { }


    public object GetItem( int index )
    {
        return Items.ToArray()[index];
    }
    public object Add(Form item)
    {
        Items.Add(item);
        return item;
    }

    public ViewItemSet ShowFieldsByName( params string[] names )
    {
        var visibleColumnsNamesList = new List<string>(names);
        Columns.ForEach((field) => { field.Visible = visibleColumnsNamesList.Contains(field.Name); });
        return this;
    }



    public ViewItemSet ToTableView()
    {
        View = "Table";

        return this;
    }


    public override ViewItem IsNotForUpdate()
    {
        base.IsNotForUpdate();
        Changed = false;
        return this;
    }

    public override ViewOptions SetEdited(bool edited)
    {
        base.SetEdited(edited);
        Items.ForEach(f=> {
            f.SetEdited(edited);
        });        
        return this;
    }
}
 
