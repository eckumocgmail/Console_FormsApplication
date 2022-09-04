using System.Collections.Generic;
using System.Reflection;

public class Searching
{

    public static bool IsPropertiesContainsText(object target, List<string> properties, string text, bool caseSensative)
    {
        bool contains = false;
        foreach(string property in properties)
        {
            if( IsPropertyContainsText(target, property, text, caseSensative))
            {
                return contains = true;
            }
        }
        return contains;
    }

    public static bool IsPropertyContainsText( object target, string property, string text, bool caseSensative )
    {
        object value = GetValue(target, property);
        if ( value == null)
        {
            return false;
        }
        else
        {
            string propertyText = value.ToString();
            if (caseSensative==false)
            {
                propertyText = propertyText.ToLower();
                text = text.ToLower();
            }
            return propertyText.IndexOf(text)!=-1;
        }
    }

    private static object GetValue(object i, string v)
    {
        PropertyInfo propertyInfo = i.GetType().GetProperty(v);
        FieldInfo fieldInfo = i.GetType().GetField(v);
        return
            fieldInfo != null ? fieldInfo.GetValue(i) :
            propertyInfo != null ? propertyInfo.GetValue(i) :
            null;
    }
}