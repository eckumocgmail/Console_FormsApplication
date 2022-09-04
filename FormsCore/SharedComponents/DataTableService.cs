using Microsoft.Extensions.DependencyInjection;
using RootForms.Shared.Collections.TableCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


/*


/// <summary>
/// Объявляет методы управления табличной моделью
/// </summary>
public interface ITableService
{

    /// <summary>
    /// Возвращает определение столбцов табличной модели согласно свойствам типа.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public TableModelComponent.TableColumn[] GetColumns(Type type);

    /// <summary>
    /// Сортирует колонки по возрастанию свойства Order, возвращает только отмеченные признаком Visible
    /// </summary>
    public TableModelComponent.TableColumn[] GetVisibleColumnsByOrder(TableModelComponent.TableColumn[] Columns);

    /// <summary>
    /// Получение контента для заданной колонки
    /// </summary>
    /// <param name="Row"></param>
    /// <param name="Column"></param>
    /// <returns></returns>
    public object GetValue(TableModelComponent.TableRow Row, string Column);
    

}




/// <summary>
/// Реализует методы управления табличной моделью
/// </summary>
public class TableService: ITableService
{

    /// <summary>
    /// Возвращает определение столбцов табличной модели согласно свойствам типа.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public TableModelComponent.TableColumn[] GetColumns(Type type)
    {
        return type.GetUserInputPropertyNames().Select(name => new TableModelComponent.TableColumn()
        {
            Name = name,
            Label = Attrs.LabelFor(type, name),
            Type = type.GetProperty(name).PropertyType,
            Visible = true
        }).ToArray();
    }


    /// <summary>
    /// Сортирует колонки по возрастанию свойства Order, возвращает только отмеченные признаком Visible
    /// </summary>
    public TableModelComponent.TableColumn[] GetVisibleColumnsByOrder(TableModelComponent.TableColumn[] Columns)
    {
        List<TableModelComponent.TableColumn> cols = Columns.Where(c => c.Visible == true).ToList();
        cols.Sort((c1, c2) => { return c2.Order - c1.Order; });
        return cols.ToArray();
    }


    /*public Table ForBusinessDataset(BusinessDataset dataset)
    {

        var table = new Table();
        dataset.Join("BusinessDatasource");
        if (dataset.BusinessDatasource != null)
        {
            var odbc = dataset.BusinessDatasource.GetOdbcDatabaseManager();
            try
            {
                odbc.Execute(dataset.Expression);
            }
            catch (Exception ex)
            {

            }
        }
        return table;
    }* /
    public Table ForCollectionProperty(object target, string property)
    {
        string typeName =
            Typing.ParseCollectionType(target.GetType().GetProperty(property).PropertyType);
        if (Typing.IsPrimitive(typeName))
        {
            return ForPrimitiveCollection(
                        target.GetType().GetProperty(property).GetValue(target),
                        ReflectionService.TypeForName(typeName),
                        Attrs.DescriptionFor(target.GetType(), property));
        }
        else
        {
            return ForCollection(
                        target.GetType().GetProperty(property).GetValue(target),
                        ReflectionService.TypeForName(typeName));
        }

    }

    public global::Table ForPrimitiveCollection(dynamic items, Type type, string caption)
    {
        global::Table tm = new global::Table();
        tm.type = type;
        tm.IsPrimitive = true;
        tm.Columns = new List<string> { caption };
        tm.Cells = new List<List<object>>();
        foreach (var item in items)
        {
            tm.Cells.Add(new List<object> { item });
        }
        tm.Editable = true;
        return tm;
    }

    public global::Table ForCollection(dynamic items, Type type)
    {
        global::Table tm = new global::Table();
        tm.type = type;
        tm.Columns = (from p in ReflectionService.GetOwnPropertyNames(type) select p).ToList();
        foreach (var item in items)
        {
            try
            {
                tm.Cells.Add(ReflectionService.Values(item, tm.Columns));
            }
            catch (Exception ex)
            {
                tm.Cells.Add(new List<object>() { 
                    "Ошибка при получении значения "+ex.Message });
            }

        }
        return tm;
    }
    /*
    public global::Table ForTableManager(TableManagerStatefull manager)
    {
        global::Table  tm = new global::Table ();
        //Dictionary<string, ColumnMetaData> columns = manager.GetMetadata().columns;
        //tm.Columns = new List<string>(columns.Keys).ToList();
        List<object[]> rows = new List<object[]>();
        /*foreach(var token in manager.SelectAll())
        {
            token.Value<object>();
        }
        tm.Cells = new List<List<object>>(); 
        return tm;
    }* /


    public Table ForDictionary(IDictionary<string, object> properties, string title)
    {
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


    /// <summary>
    /// Создание модели табличного представления из свойств обьекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public global::Table ForDictionary(object model)
    {

        /*global::Table tm = new global::Table();

        tm.Columns = ReflectionService.GetOwnMethodNames(model.GetType());
        List<object[]> cells = new List<object[]>();

        //cells
        object[] row = new object[cells.Count()];
        int i = 0;
        foreach (string column in tm.Columns)
        {
            row[i++] = GetValue(model, column);
        }
        cells.Add(row);

        //tm.Cells = cells.ToArray();
        tm.Cells = new List<List<object>>();// new Newtonsoft.Json.Linq.JArray();
        return tm;* /
        return ForDictionary(Formating.ToDictionaryLabels(model), Attrs.LabelFor(model.GetType()));
    }


    /// <summary>
    /// Извлекает значение свойства из обьекта по наименованию
    /// </summary>
    /// <param name="model"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public object GetValue(TableModelComponent.TableRow i, string v)
    {
        try
        {
            PropertyInfo propertyInfo = i.Item.GetType().GetProperty(v);
            FieldInfo fieldInfo = i.Item.GetType().GetField(v);
            return
                fieldInfo != null ? fieldInfo.GetValue(i.Item) :
                propertyInfo != null ? propertyInfo.GetValue(i.Item) :
                null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении значения свойства {v} из объекта типа {i.GetType().Name} ", ex);
        }
    }
}


public static class TableServiceExtension
{
    public static IServiceCollection AddTable(this IServiceCollection services)
    {
        services.AddScoped<ITableService, TableService>();
        return services;
    }
}







namespace BlazorHospital.Client.Services.ViewServices
{

    public class DataTableService
    {
    }
}
*/