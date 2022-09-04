using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Шаблон URL")]
public class UrlTemplate: Attribute
{
    private readonly string _Template;
    public UrlTemplate( string Template )
    {
        _Template = Template;
    }
}
