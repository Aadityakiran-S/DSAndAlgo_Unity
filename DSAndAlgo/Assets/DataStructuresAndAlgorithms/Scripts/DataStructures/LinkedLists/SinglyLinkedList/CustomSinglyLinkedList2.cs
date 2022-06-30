using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomSinglyLinkedList2
{
    #region Referances

    private SinglyLinkedListEntry _head;
    private SinglyLinkedListEntry _tail;

    private int _length;
    public int Length { get => _length; private set => _length = value; }

    #endregion

    #region Constructor 

    public CustomSinglyLinkedList2(System.Object headValue)
    {
        SinglyLinkedListEntry firstHead = new SinglyLinkedListEntry(headValue);
        _head = _tail = firstHead;  //On creation of a single element, head and tail are same
        _length = 1;
    }

    #endregion

    #region Public Methods 

    public void Append(System.Object value)
    {
        SinglyLinkedListEntry newTail = new SinglyLinkedListEntry(value);
        SinglyLinkedListEntry currentTail = _tail;

        currentTail.nextEntry = newTail;
        _tail = newTail;

        _length++;
    }

    public void Prepend(System.Object value)
    {
        SinglyLinkedListEntry currentHead = _head;
        SinglyLinkedListEntry newHead = new SinglyLinkedListEntry(value, currentHead);

        _head = newHead;

        _length++;
    }

    public void Insert(int index, System.Object value)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        if (index == 0) //Then we're just prepending
        {
            Prepend(value);
        }
        else if (index == _length - 1)   //Then we're just appending
        {
            Append(value);
        }
        else  //Index is in between first and last element
        {
            int i = 0;
            SinglyLinkedListEntry previousLLItem = _head;
            SinglyLinkedListEntry nextLLItem = _head;
            while (i < index)   //Getting entries in between which we are to insert
            {
                previousLLItem = nextLLItem;
                nextLLItem = nextLLItem.nextEntry as SinglyLinkedListEntry;
                i++;
            }

            SinglyLinkedListEntry entryToInsert = new SinglyLinkedListEntry(value);
            previousLLItem.nextEntry = entryToInsert;
            entryToInsert.nextEntry = nextLLItem;

            _length++;
        }
    }

    //DOLATER: Search for the given object in the LL and remove that if exists
    public void Remove(System.Object valueToRemove)
    {
        
    }

    public void RemoveAt(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        //If removing head, simply remove head. Chaining takes care of itself
        if (index == 0)
        {
            SinglyLinkedListEntry currentHead = _head;
            _head = currentHead.nextEntry as SinglyLinkedListEntry;

            currentHead.Dispose();
            currentHead = null;
        }
        //Otherwise removing will be the same
        else
        {
            int i = 0;
            SinglyLinkedListEntry entryToRemove = _head;
            SinglyLinkedListEntry previousEntry = _head;
            while (i < index)
            {
                previousEntry = entryToRemove;
                entryToRemove = entryToRemove.nextEntry as SinglyLinkedListEntry;
                i++;
            }

            previousEntry.nextEntry = entryToRemove.nextEntry;
            _length--;

            //Garbage collection will take care of this but that's too bad ain't it?
            entryToRemove.Dispose();
            entryToRemove = null;
        }
    }

    public System.Object Retrieve(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        int i = 0; SinglyLinkedListEntry entryToRetrieve = _head;
        while (i < index)
        {
            entryToRetrieve = entryToRetrieve.nextEntry as SinglyLinkedListEntry;
            i++;
        }

        return entryToRetrieve.value;
    }

    public void PrintAllValues()
    {
        int i = 0; SinglyLinkedListEntry nextEntry = _head, currentEntry = _head;
        while (i < Length)
        {
            currentEntry = nextEntry;
            nextEntry = currentEntry.nextEntry as SinglyLinkedListEntry;  //Casting to show as log
            //To catch the null ref exception at the end
            if (nextEntry == null)
            {
                nextEntry = new SinglyLinkedListEntry("null", null);
                Debug.Log("Entry at " + i + " is " + currentEntry.value + " pointing to " + "\n" + nextEntry.value + " that is we've" +
                    "reached the tail");
            }
            else
                Debug.Log("Entry at " + i + " is " + currentEntry.value + " pointing to " + "\n" + nextEntry.value);

            i++;
        }
    }

    #endregion   
}

[System.Serializable]
public class SinglyLinkedListEntry : System.Object, IDisposable
{
    public System.Object value;
    public System.Object nextEntry;

    public SinglyLinkedListEntry(System.Object value, System.Object nextEntry = null)
    {
        this.value = value;
        this.nextEntry = nextEntry;
    }

    public void Dispose()
    {
        this.value = null;
        this.nextEntry = null;
    }
}