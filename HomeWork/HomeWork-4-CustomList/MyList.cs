using System.Collections;
namespace HomeWork_4_CustomList;

public class MyList<T> : IEnumerable<T> where T : IComparable<T>
{
    private T?[] _data;
    private int _count;
    private int _size;

    public delegate void OnResizeDelegate(int newSize);
    public event OnResizeDelegate? OnResize;

    public Action<int> OnResizeAction;
    public Func<int, int>? OnResizeFunc;
    public Predicate<int>? OnResizePredicate;

    public MyList()
    {
        _data = new T?[1];
        _count = 0;
        _size = 1;
    }

    public void Add(T? item)
    {
        if (_count == _size)
        {
            Resize();
        }
        _data[_count] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        int indexToRemove = Array.IndexOf(_data, item);
        if (indexToRemove == -1)
        {
            return false;
        }

        for (int i = indexToRemove; i < _count - 1; i++)
        {
            _data[i] = _data[i + 1];
        }

        _data[_count - 1] = default;
        _count--;

        if (_count < _size / 2)
        {
            _size = _size / 2;
            Array.Resize(ref _data, _size);
            OnResize?.Invoke(_size);
            OnResizeAction?.Invoke(_size);
            OnResizePredicate?.Invoke(_size);
            OnResizeFunc?.Invoke(_size);
        }

        return true;
    }

    public T? this[int index]
    {
        get
        {
            if (index >= 0 && index < _count)
            {
                return _data[index];
            }
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        set
        {
            if (index >= 0 && index < _count)
            {
                _data[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
    }
    
    public void Sort()
    {
        Array.Sort(_data, 0, _count);
    }

    public int Find(T item)
    {
        return Array.IndexOf(_data, item);
    }

    public static MyList<T> operator +(MyList<T> list, T item)
    {
        list.Add(item);
        return list;
    }

    public static MyList<T> operator -(MyList<T> list, T item)
    {
        list.Remove(item);
        return list;
    }

    private void Resize()
    {
        if (_size == 0) _size = 0;
        _size *= 2;
        OnResize?.Invoke(_size);
        OnResizeAction?.Invoke(_size);
        OnResizePredicate?.Invoke(_size);
        OnResizeFunc?.Invoke(_size);
        T[] tmp = new T[_size];
        for (int i = 0; i < _count; i++)
        {
            tmp[i] = _data[i];
        }
        _data = tmp;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}