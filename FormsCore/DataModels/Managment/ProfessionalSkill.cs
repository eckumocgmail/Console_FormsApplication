

using Microsoft.EntityFrameworkCore;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[EntityLabelAttribute("Профеccиональные навыки")]
[SearchTermsAttribute(nameof(Name) + "," + nameof(Description))]
public class ProfessionalSkill : DimensionTable
{

    public virtual List<EmployeeExpirience> Expirience { get; set; }
}