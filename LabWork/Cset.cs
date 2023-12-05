using System.Collections;

namespace LabWork;

/// <summary>
/// Множество
/// </summary>
/// <typeparam name="T">Тип данных, хранимых в множестве</typeparam>
internal class Cset<T> : IEnumerable<T>
{
    /// <summary>
    /// Элементы множества
    /// </summary>
    private readonly List<T> _items = new List<T>();

    public int Count => _items.Count;

    public Cset() 
    {
    }

    public Cset(params T[] items)
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }

    /// <summary>
    /// Добавление элемента в множество 
    /// </summary>
    public void Add(T newItem)
    {
        if (newItem == null)
            throw new ArgumentNullException(nameof(newItem));

        //добавляем только элементы, которых нет в множестве
        if (!_items.Contains(newItem))
            _items.Add(newItem);
    }

    /// <summary>
    /// Добавление элемента в множество 
    /// </summary>
    /// <param name="set">Множество</param>
    /// <param name="newItem">Новый элемент</param>
    /// <returns>Множество с добавленным элементом</returns>
    public static Cset<T> operator +(Cset<T> set, T newItem)
    {
        set.Add(newItem);
        return set;
    }

    /// <summary>
    /// Объединение множеств
    /// </summary>
    public Cset<T> Union(Cset<T> setToUnion)
    {
        if (setToUnion is null)
            throw new ArgumentNullException(nameof(setToUnion));

        //создаем новое множество из элементов старого
        var resultCSet = new Cset<T>(this.ToArray());

        //добавляем в новое множество элементы второго множества
        foreach (var item in setToUnion)
        {
            resultCSet.Add(item);
        }

        return resultCSet;
    }

    /// <summary>
    /// Объединение множеств
    /// </summary>
    public static Cset<T> operator +(Cset<T> set1, Cset<T> set2)
    {
        return set1.Union(set2);
    }
    
    /// <summary>
    /// Пересечение множеств
    /// </summary>
    public Cset<T> Intersection(Cset<T> setForIntersection)
    {
        if (setForIntersection is null)
            throw new ArgumentNullException(nameof(setForIntersection));

        //создаем новое множество
        var resultCSet = new Cset<T>();

        //добавляем в новое множество элементы данного множества, которые также есть во втором множестве
        foreach (var item in _items.Where(x => setForIntersection.Contains(x)))
        {
            resultCSet.Add(item);
        }

        return resultCSet;
    }

    /// <summary>
    /// Пересечение множеств
    /// </summary>
    public static Cset<T> operator *(Cset<T> set1, Cset<T> set2)
    {
        return set1.Intersection(set2);
    }

    /// <summary>
    /// Проверка множеств на равенство
    /// </summary>
    public bool Equals(Cset<T> setForEquality)
    {
        if (setForEquality is null)
            throw new ArgumentNullException(nameof(setForEquality));

        if (this.Count != setForEquality.Count)
            return false;

        foreach(var item in _items)
        {
            if (!setForEquality.Contains(item))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Проверка множеств на равенство
    /// </summary>
    public static bool operator ==(Cset<T> set1, Cset<T> set2)
    {
        return set1.Equals(set2);
    }
    public static bool operator !=(Cset<T> set1, Cset<T> set2)
    {
        return !set1.Equals(set2);
    }

    /// <summary>
    /// Мощность множества
    /// </summary>
    public static explicit operator int(Cset<T> set)
    {
        return set.Count;
    }

    public void PrintAll(string? setName = null)
    {
        Console.Write($"Элементы множества {setName}: ");

        foreach (var item in _items)
        {
            Console.Write(item + "; ");
        }

        Console.WriteLine();
    }

    #region реализация IEnumerable
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion

    ~Cset() 
    {
    }
}
