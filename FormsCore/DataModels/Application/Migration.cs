using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// 
// 
namespace Data
{
    public class Migration : BaseEntity
    {

        public DateTime DateTime { get; set; }
        public string MigrationName { get; set; }
        public string SQL { get; set; }
        public int Version { get; set; }
    }
}