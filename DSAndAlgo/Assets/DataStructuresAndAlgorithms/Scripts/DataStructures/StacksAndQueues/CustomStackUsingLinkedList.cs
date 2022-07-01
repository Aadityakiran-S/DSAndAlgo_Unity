using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CustomStackUsingLinkedList
{
    #region References and Constructor

    private DoublyLinkedListEntry _tail;

    private int _length;
    public int Length { get => _length; private set => _length = value; }

    public CustomStackUsingLinkedList(Object firstValue)
    {
        DoublyLinkedListEntry firstEntry = new DoublyLinkedListEntry(firstValue);
        _tail = firstEntry;  //On creation of a single element, head and tail are same
        _length = 1;
    }

    #endregion

    #region Public Methods

    public void Push(Object value)
    {
        DoublyLinkedListEntry newTail = new DoublyLinkedListEntry(value);
        DoublyLinkedListEntry currentTail = _tail;

        newTail.previousEntry = currentTail;
        newTail.nextEntry = null;
        currentTail.nextEntry = newTail;    //Current tail should already have a previous entry

        _tail = newTail;

        _length++;
    }

    public Object Pop()
    {
        if(Length == 0)
        {
            UnityEngine.Debug.LogWarning("Nothing more to pop");
            return default;
        }

        DoublyLinkedListEntry valueToPop = _tail;
        _tail = valueToPop.previousEntry;
        _length--;

        return valueToPop.Value;
    }

    public Object Peek()
    {
        return _tail.Value;
    }

    #endregion
}
