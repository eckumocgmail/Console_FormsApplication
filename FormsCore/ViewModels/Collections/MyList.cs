using NetCoreConstructorAngular.ActionEvent;
using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MyList  : ViewItem, IList<object>
{
    private readonly List<object> _items;
    public int Count => _items.Count();
    public bool IsReadOnly => false;


    private event EventHandler OnListChanges;


    public object Upgrade(object item)
    {
        Writing.ToConsole("OnUpgrade");
        return item;
    }


    public MyList() : base()
    {
        _items = new List<object>() { };
        _items.Add(new ListItem() { Title = "Item1" });
        _items.Add(new ListItem() { Title = "Item2" });
        OnListChanges = new EventHandler((sender, args) => {
            ListChangedEvent message = ((ListChangedEvent)args);
            ListChangesMessage changes = message.GetChanges();
            Writing.ToConsole($"Изменения {changes.Action} {changes.Item}");
        });
    }

    public MyList(List<object> collection) : base()
    {
        _items = new List<object>(collection);
    }





    public void Add(object item)
    {
        _items.Add(item);
        this.OnAdded(item);
    }
    public void OnAdded(object item)
    {
        Changed = true;
        Writing.ToConsole($"Added {item}");
        this.OnListChanges.Invoke(this, new ListChangedEvent(new ListChangesMessage()
        {
            Item = item,
            Action = "Add"
        }));
    }


    public void Insert(int index, object item)
    {
        _items.Insert(index, item);
        this.OnInserted(index, item);
    }
    public void OnInserted(int index, object item)
    {
        Changed = true;
    }


    public bool Remove(object item)
    {
        bool removed = _items.Remove(item);
        if (removed)
        {
            OnRemoved(item);
        }
        return removed;
    }
    public void OnRemoved(object item)
    {
        Changed = true;
        Writing.ToConsole($"Removed {item}");
    }

    public void RemoveAt(int index)
    {
        _items.RemoveAt(index);

        this.OnRemovedAt(index);
    }
    public void OnRemovedAt(int index)
    {
        Changed = true;
        _items.RemoveAt(index);
    }

    public void Clear()
    {
        lock (_items)
        {
            object[] arr = _items.ToArray();
            foreach (object item in arr)
            {
                this.Remove(item);
            }
        }
    }


    public IEnumerator<object> GetEnumerator()=> new MyEnumerator<object>(this);
    

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new MyEnumerator<object>(this);
    }

    public object this[int index]
    {
        get => GetItem(index);
        set => SetItem(index, value);
    }

    public object GetItem(int i)
    {
        throw new Exception();
    }

    public void SetItem(int i, object value)
    {
        throw new Exception();
    }




    public int IndexOf(object item)
    {
        return _items.IndexOf(item);
    }











    public bool Contains(object item)
    {
        return _items.Contains(item);
    }

    public void CopyTo(object[] array, int arrayIndex)
    {
        object[] arr = _items.ToArray();
        for (int i = 0; i < arr.Length; i++)
        {
            array[i] = arr[i];
        }
    }
}
