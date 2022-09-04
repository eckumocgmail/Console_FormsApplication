using System;
/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TViewItem"></typeparam>
public interface ISingleConvert<TEntity, TViewItem>
    where TEntity : BaseEntity
    where TViewItem : ViewItem
{

    /// <summary>
    /// Выполнение преобразования к модели представления
    /// </summary>
    public TViewItem ToView(TEntity pdata); 
}



/// <summary>
/// 
/// </summary>
public class TableConverter : ISingleConvert<BaseEntity, global::Table> {
    public Table ToView(BaseEntity pdata)
    {
        throw new System.NotImplementedException();
    }
}


/// <summary>
/// 
/// </summary>
public class ListConverter : ISingleConvert<HierDictionaryTable , global::List> {
    public List ToView(HierDictionaryTable  pdata)
    {
        throw new System.NotImplementedException();
    }
}


 
/// <summary>
///     Создание модели иерархического представления, из
/// иерархическому справочника. 
/// В резульате будет собрано поддерево.
/// </summary>
public class TreeConvert<THier>: ISingleConvert<THier, global::Tree>  where THier: HierDictionaryTable 
{
    private readonly TreeBuilder _treeBuilder;

    public ApplicationDbContext _db { get; }

    public TreeConvert( TreeBuilder treeBuilder,  ApplicationDbContext db )
    {
        _treeBuilder = treeBuilder;
        _db = db;
        
    }



    public Tree ToView(THier pdata)
    {
        var result = _treeBuilder.CreateDescendant(pdata,
            (record) => 
            {
                return new Tree()
                {
                    
                };
            },
            (record) => 
            {
                var cid = pdata.Get("ID").ToString();
                Func<THier, bool> isChild = (targetParent) => 
                {
                    var pid = targetParent.Get("ParentID");
                    pid = pid!=null? pid.ToString(): pid;
                    return cid == pid;
                };                
                return _db.GetDbSet(record.GetType().Name).Where(isChild).ToList();
            }
        );
        return result;
    }

     
}