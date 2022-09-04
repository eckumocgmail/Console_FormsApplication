
 
using System.Collections.Generic;

public abstract class BusinessEntity<T>: HierDictionaryTable<T>
{
    [ManyToMany("Datasets")]
    public virtual List<BusinessDataset> BusinessDataset { get; set; }



}
 