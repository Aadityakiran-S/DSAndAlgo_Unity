using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CustomQueue 
{
    #region References and Constructor

    private DoublyLinkedListEntry _head;
    private DoublyLinkedListEntry _tail;

    private int _length;
    public int Length { get => _length; private set => _length = value; }

    public CustomQueue(Object firstValue)
    {
        DoublyLinkedListEntry firstEntry = new DoublyLinkedListEntry(firstValue);
        _head = _tail = firstEntry;  //On creation of a single element, head and tail are same
        _length = 1;
    }

    #endregion

    #region Public Methods

    public void Enqueue(Object objToEnqueue)
    {
        DoublyLinkedListEntry newTail = new DoublyLinkedListEntry(objToEnqueue, null, _tail);
        _tail.nextEntry = newTail;
        _tail = newTail;

        _length++;
    }

    public Object Dequeue()
    {
        if(Length == 0)
        {
            UnityEngine.Debug.LogWarning("Nothing left to dequeue");
            return default;
        }

        DoublyLinkedListEntry entryToDeQ = _head;
        _head = _head.nextEntry;
        _length--;

        return entryToDeQ.value;
    }

    public Object Peek()
    {
        return _head.value;
    }

    #endregion
}
