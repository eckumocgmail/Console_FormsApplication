using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Image: ViewItem
{

    /// <summary>
    /// Растянуть,замостить,разместить в исходном размере
    /// </summary>
    [SelectDictionary("cover,repeat,corner")]
    public string Position { get; set; }

    public string Source { get; set; }
}