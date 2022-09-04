using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMultiCountModel<TEntity> where TEntity: BaseEntity 
{
    public IEnumerable<TEntity> Items { get; set; }
    
}
