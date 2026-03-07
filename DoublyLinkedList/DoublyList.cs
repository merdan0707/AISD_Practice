namespace DoublyLinkedList;

public class DoublyList<T> 
{
    DoublyNode<T> _head;
    DoublyNode<T> _tail;

    // создания пустого списка
    public DoublyList() { }

    // создания списка с входным параметром в виде целого числа
    public DoublyList(T data)
    {
        _head = new DoublyNode<T>(data);
        _tail = _head;
    }
    
    // создания списка с входным параметром в виде массива целых чисел
    public DoublyList(T [] array)
    {
        foreach (var data in array)
            Add(data);
    }
    
    // добавление значения (по умолчанию в конец)
    public void Add(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = _head;
            return;
        }
        
        DoublyNode<T> temp = _head;
        while (temp != null)
        {
            if (temp.Next == null)
            {
                temp.Next = newNode;
                newNode.Previous = temp;
                _tail = newNode;
                return;
            }
            temp = temp.Next;
        }
    }
    
    // добавление значения в начало
    public void AddFirst(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        if (Count() == 0)
        {
            _head = newNode;
            _tail = _head;
            return;
        }
        
        newNode.Next = _head;
        _head.Previous = newNode;
        _head = newNode;
    }
    
    // добавление элемента на какую-то позицию (позиции от 1)
    public void AddPosition(int position, T data)
    {
        if (position < 1 || position > Count())
        {
            Console.WriteLine($"Position {position} is out of range.");
            return;
        }
        
        DoublyNode<T> temp = _head;
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        int count = 1;

        if (position == 1)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }
        
        while (temp != null)
        {
            if (count == position)
            {
                newNode.Previous = temp.Previous;
                newNode.Next = temp;
                temp.Previous.Next = newNode;
                temp.Previous = newNode;
                return;
            }
            temp = temp.Next;
            count++;
        }
    }
    
    // добавления диапазона значений (AddRange)
    public void AddRange(T[] array)
    {
        foreach (var data in array)
            Add(data);
    }
    
    // удаление элемента с конца
    public void RemoveLast()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (Count() == 1)
        {
            _head = null;
            _tail = null;
            return;
        }
        DoublyNode<T> temp = _head;
        while (temp != null)
        {
            if (temp.Next == null)
            {
                _tail = temp.Previous;
                temp.Previous.Next = null;
                return;
            }
            temp = temp.Next;
        }
    }
    
    // удаление первого элемента 
    public void RemoveFirst()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (Count() == 1)
        {
            _head = null;
            _tail = null;
            return;
        }
        
        _head = _head.Next;
        _head.Previous = null;
    }
    
    // удаление элемента на какой-то позиции
    public void RemoveInPosition(int position)
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (position < 1 || position > Count())
        {
            Console.WriteLine($"Position {position} is out of range.");
            return;
        }

        if (position == 1)
        {
            RemoveFirst();
            return;
        }

        if (position == Count())
        {
            RemoveLast();
            return;
        }
        
        // DoublyNode<T> temp = _head;
        // int count = 1;
        // while (temp != null)
        // {
        //     if (count == position)
        //     {
        //         temp.Next.Previous = temp.Previous;
        //         temp.Previous.Next = temp.Next;
        //         return;
        //     }
        //     temp = temp.Next;
        // }
    }



    // размер линейного списка
    public int Count()
    {
        if  (_head is null) return 0;
        int  count = 0;
        DoublyNode<T> temp = _head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }

    // вывод списка
    public void Print()
    {
        DoublyNode<T> temp = _head;
        while (temp != null)
        {
            Console.Write($"{temp.Data}" + (temp.Next==null?"\n" :" -> "));
            temp = temp.Next;
        }
        Console.WriteLine($"Count of elements: {Count()}");
    }
}