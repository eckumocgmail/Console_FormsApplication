using System;
using System.Collections.Generic;
using System.Linq;


public class ListService 
{
    private readonly IUserModelsService _models;

    public ListService( IUserModelsService models ) 
    {
        _models = models;
    }

    public object SingleSelect( List<string> items )
    {        
        return IntoSession(new List(){ 
            ListItems = items.AsQueryable().Select<string, ViewItem>(text => new ListItem() { Title = text }).ToList()
        });
    }

    public object IntoSession(object viewModel)
    {
        _models.RegistrateModel(viewModel);
        return viewModel;
    }


    public void Update( List list )
    {
        list.ListItems.ForEach((listitem) => {
            if( list.Children.Contains(listitem) == false)
            {
                list.Append(listitem);
            }
        });
        List<ViewNode> toRemove = new List<ViewNode>();
        list.Children.ForEach((p) => { 
            if( p is ListItem)
            {
                if (list.ListItems.Contains(p) == false)
                {
                    toRemove.Add(p);
                }
            }
        });
        toRemove.ForEach((p) => {
            p.RemoveFromParent();

        });
        list.Children.ForEach((p) => {
            if (p is ListItem)
            {
                ((ListItem)p).Selectable = list.Selectable;
            }
        });
    }



    /// <summary>
    /// Создание списка для 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="items"></param>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public global::List CreateForCollection(string title, dynamic items, string typeName, Func<object,object> create)
    {
        Type type = ReflectionService.TypeForShortName(typeName);
        if( type == null)
        {
            throw new Exception($"Тип {typeName} элемента списка задан неверно");
        }
        Dictionary<string, string> bindings = new Dictionary<string, string>();
        bindings["Title"] = Expressions.GetUniqTextExpressionFor(type);
        bindings["Href"] = "/DatabaseEditor/{{GetType().Name}}/Edit/{{ID}}";

        return CreateForCollection(title, items, typeName, bindings, create);
    }



    



    public global::List CreateForCollection( string title, dynamic items, string type, Dictionary<string,string> bindings, Func<object, object> create)
    {
        List<ViewItem> lisitems = new List<ViewItem>() {};
        foreach(var item in items)
        {
            var listitem = new ListItem()
            {
                DataSet = item,
                Title = item.ID + ") " + item.GetLabel(),
                Bindings = bindings
            };
            listitem.Changed = false;
            lisitems.Add(listitem);
        } 
        
        var list = new List() {
            Chapter = title,
            Icon = Attrs.IconFor(type),
            Type = ReflectionService.TypeForName(type),
            ListItems = lisitems,          
            Bindings = bindings
        };
        list.Changed = false;
        list.Create = create;
        return list;            
    }



    public List AddControlPane( List listView, string typeOfItem ) {
        
        return listView;
    }


}