
using Newtonsoft.Json;

using System.Collections.Generic;

public class Link: ViewItem, ILink
{
    public string Icon { get; set; }
    public string Label { get; set; }
    public string Href { get; set; }
    public bool IsActive { get; set; } = false;
    public string Tooltip { get; set; }
    public List<ILink> ChildLinks { get; set; }


    [JsonIgnore()]
    public object Item { get; set; }
}