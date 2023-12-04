namespace LabWork;

internal class MyLinkedList<T>
{
    internal class Node<NodeType> where NodeType : T
    {
        public NodeType? Value { get; set; }
        public Node<NodeType>? Prev { get; set; }
        public Node<NodeType>? Next { get; set; }
    }

    private Node<T>? _head;
    private Node<T>? _tail;

    public Node<T>? Head => _head;

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public MyLinkedList()
    {
        Console.WriteLine("Вызван конструктор без параметров");
    }

    /// <summary>
    /// Конструктор с параметрами 
    /// </summary>
    /// <param name="values">Элементы из которых будет создан список</param>
    public MyLinkedList(params T[] values)
    {
        Console.WriteLine("Вызван конструктор с параметрами");

        _head = new Node<T>();
        _head.Value = values[0];

        _tail = _head;

        foreach (var value in values.Skip(1))
        {
            this.Add(value);
        }
    }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="listToCopy">Копируемый список</param>
    public MyLinkedList(MyLinkedList<T> listToCopy)
    {
        Console.WriteLine("Вызван конструктор копирования");

        if (listToCopy == null)
            throw new ArgumentNullException(nameof(listToCopy));

        if (listToCopy.Head == null)
            return;

        var nodeToCopy = listToCopy.Head;

        while (nodeToCopy != null)
        {
            this.Add(nodeToCopy.Value);
            nodeToCopy = nodeToCopy.Next;
        }
    }


    /// <summary>
    /// Вывод элементов списка от начала и от конца
    /// </summary>
    public void PrintAll()
    {
        Console.Write("Вывод элементов списка: ");

        if (_head == null)
        {
            Console.Write("Список пуст");
            return;
        }

        Node<T>? current = _head;

        do
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        while (current != null);

        Console.WriteLine();
    }

    /// <summary>
    /// Добавление элемента в список
    /// </summary>
    /// <param name="newItem">Новый элемент</param>
    public void Add(T? newItem)
    {
        if (_head == null)
        {
            AddFirst(newItem);
            return;
        }

        Node<T> newNode = new Node<T>();
        newNode.Value = newItem;
        newNode.Prev = _tail;

        _tail!.Next = newNode;

        _tail = newNode;
    }

    private void AddFirst(T? newItem)
    {
        Node<T> newNode = new Node<T>();
        newNode.Value = newItem;

        _head = newNode;
        _tail = _head;
    }

    /// <summary>
    /// Удаление элемента из списка
    /// </summary>
    /// <param name="itemToRemove">Элемент, который нужно удалить</param>
    public void Remove(Node<T> itemToRemove)
    {
        if (itemToRemove == null)
            throw new ArgumentNullException(nameof(itemToRemove));

        if (itemToRemove.Prev != null)
            itemToRemove.Prev.Next = itemToRemove.Next;

        if (itemToRemove.Next != null)
            itemToRemove.Next.Prev = itemToRemove.Prev;

        if (_head == itemToRemove)
            _head = itemToRemove.Next;

        if (_tail == itemToRemove)
            _tail = itemToRemove.Prev;
    }

    /// <summary>
    /// Поиск первого элемента в списке, содержащего указанное значение
    /// </summary>
    /// <returns>Первый найденный элемент списка, содержащий указанное значение, иначе null</returns>
    public Node<T>? Find(T value)
    {
        if (_head == null)
        {
            Console.WriteLine("Список пуст");
            return null;
        }

        Node<T>? current = _head;

        do
        {
            if (value == null && current.Value == null)
                return current;
            else if (current.Value != null && current.Value.Equals(value))
                return current;

            current = current.Next;
        }
        while (current != null);

        return null;
    }

    /// <summary>
    /// Деструктор
    /// </summary>
    ~MyLinkedList() 
    {
        Console.WriteLine("Вызван деструктор");
    }
}
