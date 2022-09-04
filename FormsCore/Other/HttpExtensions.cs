 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HttpExtensions
{

    public static string GetEntityDetailsRoute(BaseEntity target)
    {
        return "/DatabaseEditor/{{GetType().Name}}/Edit/{{ID}}";
    }
    /// <summary>
    /// дописать  метод должен вовращать код клиента
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="path"></param>
    public static void ToHttpClient( this string typeName, List<string> path )
    {
        var type = typeName.ToType();
        path.Add(type.Name.ToKebabStyle());
        //MicroServiceProvider.GetSkeleton(type.New(), path);
    }
    

}
