using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomLinkedList2
{
    #region Referances

    [System.Serializable]
    public class LinkedListEntry : System.Object, IDisposable
    {
        public System.Object value;
        public System.Object nextEntry;

        public LinkedListEntry(System.Object value, System.Object nextEntry = null)
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

    private LinkedListEntry _head;
    private LinkedListEntry _tail;

    private int _length;
    public int Length { get => _length; private set => _length = value; }

    #endregion

    #region Constructor 

    public CustomLinkedList2(System.Object headValue)
    {
        LinkedListEntry firstHead = new LinkedListEntry(headValue);
        _head = _tail = firstHead;  //On creation of a single element, head and tail are same
        _length = 1;
    }

    #endregion


    #region Public Methods 

    public void Append(System.Object value)
    {
        LinkedListEntry newTail = new LinkedListEntry(value);
        LinkedListEntry currentTail = _tail;

        currentTail.nextEntry = newTail;
        _tail = newTail;

        _length++;
    }

    public void Prepend(System.Object value)
    {
        LinkedListEntry currentHead = _head;
        LinkedListEntry newHead = new LinkedListEntry(value, currentHead);

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
            LinkedListEntry previousLLItem = _head;
            LinkedListEntry nextLLItem = _head;
            while (i < index)   //Getting entries in between which we are to insert
            {
                previousLLItem = nextLLItem;
                nextLLItem = nextLLItem.nextEntry as LinkedListEntry;
                i++;
            }

            LinkedListEntry entryToInsert = new LinkedListEntry(value);
            previousLLItem.nextEntry = entryToInsert;
            entryToInsert.nextEntry = nextLLItem;

            _length++;
        }
    }

    public void Remove(System.Object valueToRemove)
    {
        int i = 0;
        LinkedListEntry entryToRemove = _head;
        LinkedListEntry previousEntry = _head;
        while (i < Length)
        {
            if (entryToRemove.value == valueToRemove)
            {
                previousEntry.nextEntry = entryToRemove.nextEntry;
                break;
            }
            else
            {

            }


            previousEntry = entryToRemove;
            entryToRemove = entryToRemove.nextEntry as LinkedListEntry;
            i++;
        }

        previousEntry.nextEntry = entryToRemove.nextEntry;
        _length--;
    }

    public void RemoveAt(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        //If removing head, simply remove head. Chaining takes care of itself
        if (index == 0)
        {
            LinkedListEntry currentHead = _head;
            _head = currentHead.nextEntry as LinkedListEntry;

            currentHead.Dispose();
            currentHead = null;
        }
        //Otherwise removing will be the same
        else
        {
            int i = 0;
            LinkedListEntry entryToRemove = _head;
            LinkedListEntry previousEntry = _head;
            while (i < index)
            {
                previousEntry = entryToRemove;
                entryToRemove = entryToRemove.nextEntry as LinkedListEntry;
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

        int i = 0; LinkedListEntry entryToRetrieve = _head;
        while (i < index)
        {
            entryToRetrieve = entryToRetrieve.nextEntry as LinkedListEntry;
            i++;
        }

        return entryToRetrieve.value;
    }

    public void PrintAllValues()
    {
        int i = 0; LinkedListEntry nextEntry = _head, currentEntry = _head;
        while (i < Length)
        {
            currentEntry = nextEntry;
            nextEntry = currentEntry.nextEntry as LinkedListEntry;  //Casting to show as log
            //To catch the null ref exception at the end
            if (nextEntry == null)
            {
                nextEntry = new LinkedListEntry("null", null);
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
