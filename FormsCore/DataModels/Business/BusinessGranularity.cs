using System;
using System.Collections.Generic;
using System.Text;


[EntityLabel("Паралельность(периодичность)")]
[SystemEntity()]
public class BusinessGranularities : DimensionTable
{


    [UniqValidation()]
    public string Code { get; set; }

}