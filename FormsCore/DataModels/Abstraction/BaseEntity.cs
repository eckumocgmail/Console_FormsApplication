 

using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
 
 
public partial class BaseEntity 
{

   
    public static class Attrs  
    {

    }


    [NotMapped]
    [NotInput()]
    public object Item { get; set; }

    [NotInput()]
    [NotMapped]
    [InputHidden(true)]
    public object Value
    {
        get
        {
            return Item;
        }
        set
        {
            Item = value;
        }
    }



    //public object this[string prop] => Compile(prop);

    public object Compile(string expression) {
        return Expression.Compile(expression,this);
    }

    public object Get(string prop)
    {    
        
        return ReflectionService.GetValueFor(this,prop);
    }

    public Table ToDictionaryTable()
    {
        var properties = this.ToDictionary();
        var title = AttrUtils.LabelFor(GetType());
        var table = new Table();
        table.Title = title;
        table.Searchable = true;
        table.Columns = new List<string> { "Ключ", "Значение" };
        table.Cells = new List<List<object>>();
        foreach (var p in properties)
        {
            table.Cells.Add(new List<object> { p.Key, p.Value });
        }
        return table;
    }

    public Card ToCard()
    {
        return new CardService().ForEntity(this);
    }

    public Form ToForm()
    {
        return new Form(this);
    }

    public Wizzard ToInputWizzard() {
        Wizzard wizard = new Wizzard();
        foreach( INavigation pnav in this.GetNotNullableNavigations())
        {
            var prop = GetType().GetProperty(pnav.Name);
            if (prop.GetValue(this) != null)
            {
                continue;
            }
            var propertyType = prop.PropertyType;
            //ViewItem next = null;
            if (Typing.IsCollectionType(propertyType))
            {
                if(Attrs.IsManyToManyRelation(this.GetType(), pnav.Name))
                {

                }
                else
                {
                    


                    /*new ListService().CreateForCollection(
                        Attrs.LabelFor(GetType(), prop.Name),
                        prop.GetValue(this),
                        prop.PropertyType.Name,
                        (ptarget) => {
                            return ptarget;
                        }
                    );*/
                }
            }
            else
            {
                //next = ReflectionService.CreateWithDefaultConstructor<BaseEntity>(propertyType).ToForm();
                //wizard.SetNextDialog(next);
            }

            //
                    
        }
        wizard.SetNextDialog(this.ToForm());
        return wizard;
    }

    
    public IList<INavigation> GetNotNullableNavigations() {
        var ctrl = this;
        return (from p in GetNavigations() where Typing.IsNullable(ctrl.GetType().GetProperty(p.Name)) == false select p).ToList();
    }




    /// <summary>
    /// Список свойств навигации
    /// </summary>
    /// <returns></returns>
    public IEnumerable<INavigation> GetNavigations()
    {
        return Attrs.GetNavigation(GetType());
    }


    /// <summary>
    /// Фильтрация свовойств навигации исп. функцию спецификации
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    private List<string> GetQualifiedRelationsWith(Func<Type, bool> filter)
    {
        var ctrl = this;
        
        Func<INavigation, bool> IsDictionary = (nav) =>
        {
            var propertyType = ctrl.GetType().GetProperty(nav.Name).PropertyType;
            if (Typing.IsCollectionType(propertyType))
            {
                //TODO:
                return false;
            }
            else
            {
                if (filter(propertyType))
                {
                    return true;
                }
                return false;
            }
        };
        return Attrs.GetNavigation(GetType()).Where(nav=>IsDictionary(nav)).Select(p=>p.Name).ToList();
    }

    

    public List<string> GetStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsStatsTable(t);
        });
    }

    public List<string> GetDailyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsDailyStatsTable(t);
        });
    }

    public List<string> GetWeeklyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsWeeklyStatsTable(t);
        });
    }

    public List<string> GetMonthlyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsStatsTable(t);
        });
    }

    public List<string> GetDimensions()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsDimensionTable(t);
        });
    }

    public List<string> GetFacts()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsFactsTable(t);
        });
    }


    public List<string> GetHiers()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsHierDictinary(t);
        });
    }
     
    public object JoinAll()
    {
        foreach(var nav in Attrs.GetNavigation(GetType()))
        {
            Join(nav.Name);            
        }
        return this;
    }
    public object Join(string propertyName)
    {
        /*object value = null;
        if (Typing.IsCollectionType(GetType().GetProperty(propertyName).PropertyType))
        {
            string entity = Typing.ParseCollectionType(GetType().GetProperty(propertyName).PropertyType);
            using (var db = new ApplicationDbContext())
            {
                
                var nav = Attrs.GetNavigationKeyFor(entity, this.GetType());
                string p = nav.Name+"ID";
                var q = db.GetDbSet(entity);
                List<BaseEntity> resultSet = new List<BaseEntity>();
                foreach (var item in q)
                {
                    if(ReflectionService.GetValueFor(item, p).ToString() == this.ID.ToString())
                    {
                        resultSet.Add((BaseEntity)item);
                    }
                }
                 
                
                if (Typing.IsCollectionType(GetType().GetProperty(propertyName).PropertyType))
                {
                 
                    object pproperty = Get(propertyName);
                    resultSet.ForEach(next=> pproperty.GetType().GetMethod("Add").Invoke(pproperty, new object[] { next }));
                    
                   
                }
                else
                {
                    value = q.FirstOrDefault();
                    Setter.SetValue(this, propertyName, value);
                }
                
                //value = (from item in ((IQueryable<BaseEntity>)(db.GetDbSet(entity))) where ReflectionService.GetValueFor(item, p).ToString() == this.ID.ToString() select p).ToList();
                //(from p in list where ReflectionService.GetValueFor(p, zz) select p).ToList();
            }

            ;
        }
        else
        {
            object pid = GetValue(propertyName + "ID");
            if (pid != null)
            {
                int id = int.Parse(pid.ToString());
                using (var db = new ApplicationDbContext())
                {
                    string entity = GetType().GetProperty(propertyName).PropertyType.Name;
                    var cruds = new CRUDS(db);
                    value = cruds.Find(entity, id);
                }                    
                Setter.SetValue(this, propertyName, value);
            }


        }*/
        return this;
    }    
    public string ToText()
    {
        string text = "";
        ReflectionService.GetOwnPropertyNames(this.GetType()).ForEach(p => { text += ReflectionService.GetValueFor(this,p)+" ";   });
        return "ID";
    }
    public void Create()
    {
        /*using (var db = new ApplicationDbContext())
        {
            db.Add(this);
            db.SaveChanges();
        }*/
    }

    public void Update()
    {
        /*using (var db = new ApplicationDbContext())
        {
            db.Update(this);
            db.SaveChanges();
        }*/
    }

    public void Delete()
    {
        /*using (var db = new ApplicationDbContext())
        {
            var cruds = new CRUDS(db);
            cruds.Delete(this);
        }*/
    }

    public void Refresh()
    {
       /* using (var db = new ApplicationDbContext())
        {
            object data = db.GetDbSet(GetType().Name).Find(this.ID);
            new ReflectionService().copy(data, this);
        }*/
    }


    /// <summary>
    /// Получение списка имён свойств определённых в обьекте
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string GetLabel()
    {
        object target = this;
        return Attrs.LabelFor(target);
    }


    /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> results = new List<ValidationResult>();
        Dictionary<string, List<string>> errors = Validate();
        foreach(var errorEntry in errors)
        {
            string propertyName = errorEntry.Key;
            List<string> propertyErrors = errorEntry.Value;
            foreach(string propertyError in propertyErrors)
            {
                ValidationResult result = new ValidationResult(propertyError, new List<string>() { propertyName });               
                results.Add(result);
            }
        }        
        return results;
    }
    */

    /// <summary>
    /// Текст надписи, ан-но <label asp-for=""></label>
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public string LabelFor(string Name)
    {
        Dictionary<string, string> attrs = Attrs.ForProperty(this.GetType(), Name);
        if (attrs.ContainsKey(nameof(LabelAttribute)) == false)
        {
            throw new Exception($"Для создания надписи с именем поля ввода " +
                $"установите атрибут Label на свойство {Name} в классе {GetType().Name}");
        }
        else
        {
            return attrs[nameof(LabelAttribute)];
        }
    }

    public void SetValue(string key, object value)
    {
        PropertyInfo prop = this.GetType().GetProperty(key);
        if (prop != null)
        {
            prop.SetValue(this, value);
        }
        FieldInfo field = this.GetType().GetField(key);
        if (field != null)
        {
            field.SetValue(this, value);
        }
    }


    /// <summary>
    /// Получение описания определённого через атрибуты
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string GetDescription( )
    {
        BaseEntity target = this;
        return Attrs.DescriptionFor(target);
    }


    


    public object GetValue(string name)
    {    
        PropertyInfo propertyInfo = this.GetType().GetProperty(name);
        FieldInfo fieldInfo = this.GetType().GetField(name);
        return
            fieldInfo != null ? fieldInfo.GetValue(this) :
            propertyInfo != null ? propertyInfo.GetValue(this) :
            null;

    }


    /// <summary>
    /// Валидация модели по правилам определённым через атрибуты
    /// </summary>
    /// <returns></returns>
    public override Dictionary<string, List<string>> Validate(  )
    {
        BaseEntity target = this;
        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
        foreach (var property in target.GetType().GetProperties())
        {
            string key = property.Name;

            if (Typing.IsPrimitive(property.PropertyType))
            {
                List<string> errors = Validate(key);
                if (errors.Count > 0)
                {
                    result[key] = errors;
                }

            }
        }
        var optional = ValidateOptional();
        foreach (var p in optional)
        {
            if (result.ContainsKey(p.Key))
            {
                result[p.Key].AddRange(optional[p.Key]);
            }
            else
            {
                result[p.Key] = optional[p.Key];
            }
        }


        return result;
    }


    /*public virtual Dictionary<string, List<string>> ValidateOptional()
    {
        return new Dictionary<string, List<string>>();
    }*/


  
}

