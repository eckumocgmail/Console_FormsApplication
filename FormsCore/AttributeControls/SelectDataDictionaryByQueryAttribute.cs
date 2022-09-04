using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SelectDataDictionaryByQueryAttribute : ControlAttribute
{
    private readonly string _sql;


    public SelectDataDictionaryByQueryAttribute(string sql)
    {
        _sql = sql;
    }




    public override ViewItem CreateControl(FormField field)
    {
        /*using (var db = new ApplicationDbContext())
        {
            db.ExecuteQuery(_sql);
        }
        Dictionary<object, object> options = new Dictionary<object, object>();


        return new Select()
        {
            Options = options
        };*/
        throw new Exception("CreateControl");
    }

    public override ViewItem CreateControl(InputFormField field)
    {
        throw new NotImplementedException();
    }
}