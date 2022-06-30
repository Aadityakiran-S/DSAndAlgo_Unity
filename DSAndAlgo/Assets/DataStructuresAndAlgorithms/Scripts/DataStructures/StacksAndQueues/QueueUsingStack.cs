using System.Collections;
using System.Collections.Generic;

public class QueueUsingStack<T>
{
    #region References and Constructor

    private Stack<T> _stack;

    public int Length { get => _stack.Count; }

    public QueueUsingStack()
    {
        _stack = new Stack<T>();
    }

    #endregion

    #region Public Methods

    public void Enqueue(T valueToEnqueue)
    {
        _stack.Push(valueToEnqueue);
    }

    public T Dequeue()
    {
        if(Length == 0)
        {
            UnityEngine.Debug.LogWarning("Nothing left to dequeue");
            return default;
        }

        Stack<T> newStack = new Stack<T>();
        T valueToDequeue = default;
        int initialLength = Length;

        for (int i = 0; i < initialLength; i++)
        {
            if(i == initialLength - 1) //No need to retain this element since this is what we're popping
            {
                valueToDequeue = _stack.Pop();
            }
            else
            {
                newStack.Push(_stack.Pop());    //newStack is reversed in order and has one element less than original
            }
        }

        //reversing newStack to retain original order
        int finalLength = newStack.Count;
        for (int i = 0; i < finalLength; i++)
        {
            _stack.Push(newStack.Pop());
        }

        return valueToDequeue;
    }

    public T Peek()
    {
        if (Length == 0)
        {
            UnityEngine.Debug.LogWarning("No elements in queue to peek");
            return default;
        }

        Stack<T> newStack = new Stack<T>(); //newStack is reversed in order and has one element less than original
        T valueToPeek = default;
        int initialLength = Length;

        for (int i = 0; i < initialLength; i++)
        {
            if (i == initialLength - 1)    //Unlike earlier, we need to add last popped element back into original stack
            {
                valueToPeek = _stack.Pop();
                newStack.Push(valueToPeek);    
            }
            else
            {
                newStack.Push(_stack.Pop());    
            }
        }

        //reversing newStack to retain original order
        int finalLength = newStack.Count;
        for (int i = 0; i < finalLength; i++)
        {
            _stack.Push(newStack.Pop());
        }

        return valueToPeek;
    }

    public void PrintAllValues()
    {
        if (Length == 0)
        {
            UnityEngine.Debug.LogWarning("Can't print anything coz you got nothing in it to print");
            return;
        }

        foreach (var item in _stack)
        {
            UnityEngine.Debug.Log(item);
        }
    }

    #endregion
}
