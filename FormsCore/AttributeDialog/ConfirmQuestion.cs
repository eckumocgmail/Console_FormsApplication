
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConfirmAttribute: BaseDialogAttribute
{
    private readonly string _Question;

    public ConfirmAttribute( string Question )
    {
        _Question = Question;
    }
}