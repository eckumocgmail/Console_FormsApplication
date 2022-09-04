using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBookModel<TEntityModel>: IMultiCountModel<TEntityModel> where TEntityModel: BaseEntity
{
    public int GetPage();
    public int GetPagesCount();
    public void SetPage(int Page, int Size );
    public IEnumerable<TEntityModel> GetItemOnPage();
}