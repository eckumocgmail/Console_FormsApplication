 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SelectDataDictionaryAttribute : ControlAttribute
{
    
    private string entity;
    private string property;

    public SelectDataDictionaryAttribute(string expression)
    {
        string[] spices = expression.Split(",");
        if (spices.Length != 2)
        {
            throw new Exception("Выражение [SelectDataDictionaryAttribute] задано неверно");
        }
        else
        {
            /*using (var db = new ApplicationDbContext())
            {
                if (db.GetEntityTypeNames().Contains(spices[0]) == false)
                {
                    throw new Exception("Выражение [SelectDataDictionaryAttribute] задано неверно. Сущность " + spices[0] + " не найдена");
                }
                else
                {
                    if (ReflectionService.TypeForName(spices[0]).GetProperty(spices[1]) == null)
                    {
                        throw new Exception("Выражение [SelectDataDictionaryAttribute] задано неверно. Сущность " + spices[0] + " не содержит определния свойства " + spices[1]);
                    }
                }
            }*/
        }

        this.entity = spices[0];
        this.property = spices[1];
    }




    public ViewItem CreateControl(object field)
    {
        Dictionary<object, object> options = new Dictionary<object, object>();
        /*using (var db = new ApplicationDbContext())
        {
            foreach (var item in db.GetDbSet(entity))
            {
                options[item.ID] = item.GetValue(property);
            }

        }*/



        return new Select()
        {
            Options = options
        };
    }

    public override ViewItem CreateControl(FormField field)
    {
        throw new NotImplementedException();
    }

    public override ViewItem CreateControl(InputFormField field)
    {
        throw new NotImplementedException();
    }
}