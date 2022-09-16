using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Greatest Priority out
public class CustomPriorityQueue
{
    #region References and Constructor

    private List<PriorityObject> _priorityQueue;

    public int Count
    {
        get
        {
            return _priorityQueue.Count;
        }
    }

    public CustomPriorityQueue(object value, int priority)
    {
        if(priority < 1)
        {
            throw new Exception("Must pass priority greater than 1");
        }

        _priorityQueue = new List<PriorityObject>();
        Insert(value, priority);
    }

    #endregion

    #region Public Methods

    public object Remove()
    {
        if (_priorityQueue.Count == 0)
        {
            throw new ArgumentOutOfRangeException("Can't throw something out of a list that's empty...");
        }

        //Swapping last element to front and removing the new last element (which was the front earlier)
        Swap(_priorityQueue.Count - 1, 0);
        object objToReturn = _priorityQueue[_priorityQueue.Count - 1].value; int lastIndex = _priorityQueue.Count - 1;
        _priorityQueue.RemoveAt(lastIndex);

        //If at this point we removed the last item then no need to proceed
        if (_priorityQueue.Count == 0)
            return objToReturn;

        int currentIndex = 0; int leftIndex = Return_LeftChildIndex(currentIndex); int rightIndex = Return_RightChildIndex(currentIndex);
        int currentObjectPriority = _priorityQueue[0].priority;

        PriorityObject leftObj = new PriorityObject();
        PriorityObject rightObj = new PriorityObject();

        //Populating the appropriate left object
        if (leftIndex == -1)
        {
            leftObj.priority = 0; leftObj.value = null;
        }
        else
            leftObj = _priorityQueue[leftIndex];

        //Populating the appropriate right object
        if (rightIndex == -1)
        {
            rightObj.priority = 0; rightObj.value = null;
        }
        else
            rightObj = _priorityQueue[rightIndex];

        //Rearranging objects such that order of priority is preserved
        //Iterating till we place last object at place where everything below it is less than itself
        while (leftObj.priority > currentObjectPriority || rightObj.priority > currentObjectPriority)
        {
            int greatestIndex = IndexOfHighestPriorityChild(leftIndex, rightIndex);

            Swap(greatestIndex, currentIndex);
            currentIndex = greatestIndex;

            leftIndex = Return_LeftChildIndex(currentIndex); rightIndex = Return_RightChildIndex(currentIndex);

            //Updating left child for next iteration
            if (leftIndex == -1) //No left child
                leftObj.priority = 0;
            else
                leftObj = _priorityQueue[leftIndex];

            //Updating right child for next iteration
            if (rightIndex == -1) //No right child
                rightObj.priority = 0;
            else
                rightObj = _priorityQueue[rightIndex];
        }

        return objToReturn;
    }

    public void Insert(object value, int priority)
    {
        PriorityObject newObj = new PriorityObject(value, priority);
        _priorityQueue.Add(newObj);

        int parentIndex = Return_ParentIndex(_priorityQueue.Count - 1);
        int currentIndex = _priorityQueue.Count - 1;
        PriorityObject parentOfCurrentObj = _priorityQueue[parentIndex];

        //Move up till we put the node at a place where it's parent is greater than it or 
        //When it's reached the very end where it itself is the greatest node
        while (parentOfCurrentObj.priority < priority && currentIndex != 0)
        {
            Swap(parentIndex, currentIndex);
            currentIndex = parentIndex;
            parentIndex = Return_ParentIndex(currentIndex);
        }
    }

    public object Peek()
    {
        if(_priorityQueue.Count == 0)
        {
            Console.WriteLine("Nothing to peek at here buddy, move along");
            return null;
        }

        return _priorityQueue[0].value;
    }

    #endregion

    #region Helper Methods

    int Return_ParentIndex(int index)
    {
        return (int)Math.Floor((float)(index - 1) / 2);
    }

    int Return_LeftChildIndex(int index)
    {
        int supposedIndex = (2 * index) + 1;

        if (supposedIndex >= _priorityQueue.Count)
            return -1;
        else
            return supposedIndex;
    }

    int Return_RightChildIndex(int index)
    {
        int supposedIndex = (2 * index) + 2;

        if (supposedIndex >= _priorityQueue.Count)
            return -1;
        else
            return supposedIndex;
    }

    void Swap(int index1, int index2)
    {
        //No need to do anything if indices are same
        if (index1 == index2)
        {
            Console.WriteLine("You are swapping the same thing");
            return;
        }

        var item1 = _priorityQueue[index1];
        var item2 = _priorityQueue[index2];

        _priorityQueue[index1] = item2;
        _priorityQueue[index2] = item1;
    }

    int IndexOfHighestPriorityChild(int leftIndex, int rightIndex)
    {
        //Both indices are in range
        if (leftIndex != -1 && rightIndex != -1)
        {
            var left = _priorityQueue[leftIndex];
            var right = _priorityQueue[rightIndex];

            if (right.priority > left.priority)
                return rightIndex;
            else
                return leftIndex;
        }
        else if (leftIndex == -1 && rightIndex != -1)
        {
            return rightIndex;
        }
        else if (leftIndex != -1 && rightIndex == -1)
        {
            return leftIndex;
        }
        else //Both are - 1
        {
            return -1;
        }
    }

    #endregion
}

public struct PriorityObject
{
    public object value;
    public int priority;

    public PriorityObject(object obj, int priority)
    {
        value = obj;
        this.priority = priority;
    }
}
