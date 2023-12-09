using System.Collections;

namespace LabWork;

internal class MyLinkedListEnumerator<T> : IEnumerator<MyLinkedList<T>.Node<T>>
{
    private readonly MyLinkedList<T>.Node<T>? _head;
    private MyLinkedList<T>.Node<T>? _current;

    public MyLinkedListEnumerator(MyLinkedList<T>.Node<T>? linkedListHead)
    {
        _head = linkedListHead;
        _current = _head;
    }

    public MyLinkedList<T>.Node<T> Current => _current!;

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (_current != null)
        {
            _current = _current.Next!;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _current = _head;
    }
}
