using Newtonsoft.Json.Linq;

using System;

public class ITStatistics
{
    public object GetAbsolutelyValue(DateTime BeginDate, DateTime EndDate, string Item, string Indicator)
    {
        return 100;
    }
    public object GetSeriesValue(DateTime BeginDate, DateTime EndDate, string Item, string Indicator)
    {
        return JObject.FromObject(new { 
            data=new float[] { 10, 20, 30, 40 }
        })["data"].Value<object>();
    }
    public string GetSeriesText(DateTime BeginDate, DateTime EndDate, string Item, string Indicator)
    {
        string text = "";
        foreach(var jval in ((JArray)GetSeriesValue(BeginDate, EndDate, Item, Indicator)))
        {
            text += jval + ", ";
        }
        if (text.EndsWith(", "))
            text = text.Substring(0,text.Length - 2);
        return text;
    }
}