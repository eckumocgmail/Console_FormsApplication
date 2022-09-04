using System;
using System.Collections;
using System.Collections.Generic;

public enum CollectionChangedType
{
    Add,Remove
}

public class CollectionChangedEvent
{
    private int index;
    private object item;

    public CollectionChangedType CollectionChangedType { get; set; }

    public CollectionChangedEvent(CollectionChangedType CollectionChangedType)
    {
        this.CollectionChangedType = CollectionChangedType;
    }

    public CollectionChangedEvent(CollectionChangedType CollectionChangedType, int index, object item) : this(CollectionChangedType)
    {
        this.index = index;
        this.item = item;
    }
}






public class ListElementsContainer<T> : IList<T>
{

    private List<T> _local = new List<T>();


    private void SendEvent(CollectionChangedEvent collectionChangedEvent)
    {
        throw new NotImplementedException();
    }



    public T this[int index]
    {
        get => _local[index];
        set => _local[index] = value;
    }

    public int IndexOf(T item)
    {
        return _local.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        _local.Insert(index,item);
        SendEvent(new CollectionChangedEvent(CollectionChangedType.Add,index,item));
    }



    public void RemoveAt(int index)
    {
        if (_local.Count >= index)
        {
            throw new ArgumentException("index");
        }
        object p  = _local[index];
        _local.RemoveAt(index);
        SendEvent(new CollectionChangedEvent(CollectionChangedType.Remove, index, p));
    }

    

    public void Add(T item)
    {
        _local.Add(item);
    }

    public void Clear()
    {
        _local.Clear( );
    }

    public bool Contains(T item)
    {
        return _local.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _local.CopyTo(array,arrayIndex);
    }

    public bool Remove(T item)
    {
        return _local.Remove(item);
    }

    public int Count => _local.Count;

 

    public IEnumerator<T> GetEnumerator()
    {
        return _local.GetEnumerator();
    }

    public bool IsReadOnly => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _local.GetEnumerator();
    }
}