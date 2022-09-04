using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleReportHighcharts.ViewModels
{
    public class PaneItem: ViewComponentStyle
    {
        public override string ToString()
        {
            return GetHashCode()+"";
        }
    }
}
