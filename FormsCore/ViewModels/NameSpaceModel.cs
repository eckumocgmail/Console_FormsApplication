using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleReportHighcharts.Models
{
    public class NameSpaceModel
    {
        public string ns { get; set; }
        public GeneratedElementModel[] ts { get; set; }
        public GeneratedElementModel[] cs { get; set; }
    }
}
