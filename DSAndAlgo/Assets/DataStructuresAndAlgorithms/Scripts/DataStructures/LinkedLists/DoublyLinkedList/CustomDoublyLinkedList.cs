using System;
using System.Collections;
using System.Collections.Generic;

public class CustomDoublyLinkedList
{
    #region Referances

    private DoublyLinkedListEntry _head;
    private DoublyLinkedListEntry _tail;

    private int _length;
    public int Length { get => _length; private set => _length = value; }

    #endregion

    #region Constructor 

    public CustomDoublyLinkedList(Object headValue)
    {
        DoublyLinkedListEntry firstHead = new DoublyLinkedListEntry(headValue);
        _head = _tail = firstHead;  //On creation of a single element, head and tail are same
        _length = 1;
    }

    #endregion

    #region Public Methods 

    public void Append(Object value)
    {
        DoublyLinkedListEntry newTail = new DoublyLinkedListEntry(value);
        DoublyLinkedListEntry currentTail = _tail;

        newTail.previousEntry = currentTail;
        newTail.nextEntry = null;
        currentTail.nextEntry = newTail;    //Current tail should already have a previous entry

        _tail = newTail;

        _length++;
    }

    public void Prepend(Object value)
    {
        DoublyLinkedListEntry currentHead = _head;
        DoublyLinkedListEntry newHead = new DoublyLinkedListEntry(value);

        newHead.previousEntry = null;
        newHead.nextEntry = currentHead;
        currentHead.previousEntry = newHead;    //Current head should already have a next entry

        _head = newHead;

        _length++;
    }

    public void Insert(int index, Object value)
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
            DoublyLinkedListEntry previousLLItem = _head;
            DoublyLinkedListEntry nextLLItem = _head;
            while (i < index)   //Traversing to the point where we're about to insert
            {
                previousLLItem = nextLLItem; /*i*/
                nextLLItem = nextLLItem.nextEntry;  /*i+1*/
                i++;
            }

            DoublyLinkedListEntry entryToInsert = new DoublyLinkedListEntry(value)
            {
                previousEntry = previousLLItem, /*i*/
                nextEntry = nextLLItem /*i+1*/
            };

            //Inserting right in between prev and next
            previousLLItem.nextEntry = entryToInsert;
            nextLLItem.previousEntry = entryToInsert;

            _length++;
        }
    }

    //DOLATER: Search for the given object in the LL and remove that if exists
    public void Remove(Object valueToRemove)
    {

    }

    public void RemoveAt(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        //If removing head, simply remove head. Chaining takes care of itself
        if (index == 0)
        {
            DoublyLinkedListEntry currentHead = _head;
            _head = currentHead.nextEntry;
            _head.previousEntry = null;

            currentHead.Dispose();
            currentHead = null;
        }
        //Otherwise removing will be the same
        else
        {
            int i = 0;
            DoublyLinkedListEntry entryToRemove = _head;
            DoublyLinkedListEntry previousEntry = _head;
            while (i < index)
            {
                previousEntry = entryToRemove;
                entryToRemove = entryToRemove.nextEntry;
                i++;
            }

            DoublyLinkedListEntry nextEntry = entryToRemove.nextEntry;

            previousEntry.nextEntry = nextEntry;
            nextEntry.previousEntry = previousEntry;
            _length--;

            //Garbage collection will take care of this but that's too bad ain't it?
            entryToRemove.Dispose();
            entryToRemove = null;
        }
    }

    public Object Retrieve(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        int i = 0; DoublyLinkedListEntry entryToRetrieve = _head;
        while (i < index)
        {
            entryToRetrieve = entryToRetrieve.nextEntry as DoublyLinkedListEntry;
            i++;
        }

        return entryToRetrieve.Value;
    }

    //What sort of reverse is this? Such a stupid brute force way to reverse
    public void Reverse_BruteForce()
    {
        int i = Length - 1; DoublyLinkedListEntry current = _tail, previous = null, next = null;
        while (i >= 0)
        {
            if (i == Length - 1)    //Condition for moving tail to head
            {
                current.nextEntry = current.previousEntry;
                current.previousEntry = null;

                _head = current;
            }
            else if (i < Length && i > 0)   //Condition for interchanging middle elements
            {
                current.nextEntry = current.previousEntry;
                current.previousEntry = next;
            }
            else //Condition when i == 0 (we've reached head)
            {
                current.previousEntry = current.nextEntry;
                current.nextEntry = null;

                _tail = current;
            }

            //Storing variables to use in next loop
            previous = current.nextEntry;   //next entry is pointing to what's behind it. So that's prev
            next = current;     //
            current = previous;

            i--;
        }
    }

    public void Reverse_Iterative()
    {
        DoublyLinkedListEntry entry = _tail;    //Starting from the bottom (now we here! ;))
        _head = _tail;  //Now the head is going to be the tail

        while (true)
        {
            //Iterative case
            entry = FlipPointersOfEntry(entry).nextEntry; //Tail's next entry is the one behind it now. So we point to that and continue

            //Base case
            if (entry.previousEntry == null) //We've reached head
            {
                _tail = entry; // the tail is going to be what was previously the head
                FlipPointersOfEntry(entry);
                return;
            }
        }
    }

    public void Reverse_Recursive()
    {
        _head = _tail;
        RecursivelyFlipEntries(_head);
    }

    public void PrintAllValues_BruteForce()
    {
        int i = 0; DoublyLinkedListEntry currentEntry = _head, nextEntry = _head, previousEntry = _head;
        while (i < Length)
        {
            currentEntry = nextEntry;   //Step that increments
            nextEntry = currentEntry.nextEntry;  //Casting to show as log
            previousEntry = currentEntry.previousEntry;
            //To catch the null ref exception at the end
            if (nextEntry == null)
            {
                nextEntry = new DoublyLinkedListEntry("null", null);
                UnityEngine.Debug.Log("Entry at " + i + " is " + currentEntry.Value + " pointing from " + currentEntry.previousEntry.Value +
                    " pointing to " + nextEntry.Value + " that is we've reached the tail");
            }
            else if (previousEntry == null)
            {
                previousEntry = new DoublyLinkedListEntry("null");
                UnityEngine.Debug.Log("Entry at " + i + " is " + currentEntry.Value + " pointing from: " + previousEntry.Value +
                    " that's how we know we've just started & pointing to: " + currentEntry.nextEntry.Value);
            }
            else //Both current and previous entries are not null. Means we're in the middle of the list
            {
                UnityEngine.Debug.Log("Entry at " + i + " is " + currentEntry.Value + " pointing from " + currentEntry.previousEntry.Value
                    + " pointing to: " + currentEntry.nextEntry.Value);
            }

            i++;
        }
    }

    public void PrintAllValues_Iterative()
    {
        DoublyLinkedListEntry entry = _head; //Starting from head
        UnityEngine.Debug.Log("from null " + " at " + entry.Value + " next: " + entry.nextEntry.Value);

        while (true)
        {
            entry = entry.nextEntry;
            if (entry.nextEntry == null)    //We've reached tail => Print once and exit
            {
                UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " to null");
                return;
            }

            UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " next: " + entry.nextEntry.Value);
        }
    }

    public void PrintAllValues_Recursive()
    {
        RecursivePrint(_head);
    }

    public void PrintAllValues_ReverseRecursive()
    {
        ReverseRecursivePrint(_head);
    }

    #endregion

    #region Private Functions

    private DoublyLinkedListEntry FlipPointersOfEntry(DoublyLinkedListEntry entry)
    {
        DoublyLinkedListEntry tempEntry = new DoublyLinkedListEntry(entry.Value, entry.nextEntry, entry.previousEntry);

        entry.nextEntry = tempEntry.previousEntry;
        entry.previousEntry = tempEntry.nextEntry;

        tempEntry.Dispose();
        return entry;
    }

    private void RecursivelyFlipEntries(DoublyLinkedListEntry entry)
    {
        //Base case: Reaching head from behind
        if (entry.previousEntry == null)
        {
            entry = FlipPointersOfEntry(entry);
            _tail = entry;
            return;
        }

        //Flipping entries and so the next entry to flip will be the prev entry which is entry.nxt (get it?)
        entry = FlipPointersOfEntry(entry);
        RecursivelyFlipEntries(entry.nextEntry);//Starting from last, going back after flipping next entry to consider is entry.nxt
    }

    private void RecursivePrint(DoublyLinkedListEntry entry)
    {
        if (entry.nextEntry == null)//traversed to tail
        {
            UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " to null");
            return;
        }

        if (entry.previousEntry == null) //At head
        {
            UnityEngine.Debug.Log("from null, at " + entry.Value + " next: " + entry.nextEntry.Value);
        }
        else
        {
            UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " next: " + entry.nextEntry.Value);
        }

        RecursivePrint(entry.nextEntry);
    }

    private void ReverseRecursivePrint(DoublyLinkedListEntry entry)
    {
        if (entry.nextEntry == null)//traversed to tail
        {
            UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " to null");
            return;
        }

        ReverseRecursivePrint(entry.nextEntry);

        if (entry.previousEntry == null) //At head
        {
            UnityEngine.Debug.Log("from null, at " + entry.Value + " next: " + entry.nextEntry.Value);
        }
        else
        {
            UnityEngine.Debug.Log("prev: " + entry.previousEntry.Value + " at " + entry.Value + " next: " + entry.nextEntry.Value);
        }
    }

    #endregion
}

[System.Serializable]
public class DoublyLinkedListEntry : IDisposable
{
    private Object _value;
    public object Value { get => _value; private set => this._value = value; }

    public DoublyLinkedListEntry nextEntry;
    public DoublyLinkedListEntry previousEntry;

    public DoublyLinkedListEntry(Object value, DoublyLinkedListEntry nextEntry = null, DoublyLinkedListEntry prevEntry = null)
    {
        this.Value = value;
        this.nextEntry = nextEntry;
        this.previousEntry = prevEntry;
    }

    //Not really required since automatic garbage collection is there in C#
    public void Dispose()
    {
        this.Value = null;
        this.nextEntry = null;
        this.previousEntry = null;
    }
}
