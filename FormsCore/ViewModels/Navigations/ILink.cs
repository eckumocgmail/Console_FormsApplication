using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface ILink
{
    public string Icon { get; set; }
    public string Label { get; set; }
    public string Tooltip { get; set; }
    public string Href { get; set; }

    [JsonIgnore()]
    public object Item { get; set; }
    public bool IsActive { get; set; }
    public List<ILink> ChildLinks { get; set; }
}