using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQueue : MonoBehaviour
{
    #region Question

    //Implement a first in first out (FIFO) queue using only two stacks.The implemented queue should support all the functions of
    //a normal queue (push, peek, pop, and empty).

    //Implement the MyQueue class:

    //void push(int x) Pushes element x to the back of the queue.
    //int pop() Removes the element from the front of the queue and returns it.
    //int peek() Returns the element at the front of the queue.
    //boolean empty() Returns true if the queue is empty, false otherwise.

    //Notes:

    //You must use only standard operations of a stack, which means only push to top, peek/pop from top, size,
    //and is empty operations are valid.
    //Depending on your language, the stack may not be supported natively. You may simulate a stack using a
    //list or deque(double-ended queue) as long as you use only a stack's standard operations.

    //Example 1:

    //Input
    //["MyQueue", "push", "push", "peek", "pop", "empty"]
    //[[], [1], [2], [], [], []]

    //Output
    //[null, null, null, 1, 1, false]

    //Explanation
    //MyQueue myQueue = new MyQueue();
    //myQueue.push(1); // queue is: [1]
    //myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
    //myQueue.peek(); // return 1
    //myQueue.pop(); // return 1, queue is [2]
    //myQueue.empty(); // return false

    //Constraints:

    //1 <= x <= 9
    //At most 100 calls will be made to push, pop, peek, and empty.
    //All the calls to pop and peek are valid.

    //Follow-up: Can you implement the queue such that each operation is amortized O(1) time complexity?
    //In other words, performing n operations will take overall O(n) time even if one of those operations may take longer.

    #endregion

    #region References and Constructor

    private Stack<int> _stackLikeStack; //Stores whatever comes in
    private Stack<int> _queueLikeStack; //A stack in reverse order which we can use for our pop and peek functions

    public MyQueue()
    {
        _stackLikeStack = new Stack<int>();
        _queueLikeStack = new Stack<int>();
    }

    #endregion

    #region Methods

    //Pushing means simply push into stackLikeStack
    public void Push(int x)
    {
        _stackLikeStack.Push(x);
    }

    //Pop means return the first element
    public int Pop()
    {
        if (this.Empty())
        {
            System.Console.WriteLine("Can't pop anything from an empty queue");
            return 0;
        }

        int intToReturn;

        //If nothing is there in queue like stack, then
        //We need to dump everything from the other into this to reverse order
        //and bring the last element out
        if (_queueLikeStack.Count == 0) 
        {
            while (_stackLikeStack.Count != 0)
            {
                _queueLikeStack.Push(_stackLikeStack.Pop());
            }

            intToReturn = _queueLikeStack.Pop();
        }
        else //If something is in the queue like stack, then simply we can pop from that
        {
            intToReturn = _queueLikeStack.Pop();
        }

        return intToReturn;
    }

    //Same as pop but peek out the last element
    public int Peek()
    {
        if (this.Empty())
        {
            System.Console.WriteLine("Can't peek anything from an empty queue");
            return 0;
        }

        int intToPeek;

        if (_queueLikeStack.Count == 0)
        {
            while (_stackLikeStack.Count != 0)
            {
                _queueLikeStack.Push(_stackLikeStack.Pop());
            }

            intToPeek = _queueLikeStack.Peek();
        }
        else
        {
            intToPeek = _queueLikeStack.Peek();
        }

        return intToPeek;
    }

    //If there's nothing in both stacks, then only it's empty
    public bool Empty()
    {
        return _queueLikeStack.Count == 0 && _stackLikeStack.Count == 0;
    }

    #endregion
}

/*
  Your MyQueue object will be instantiated and called as such:
  MyQueue obj = new MyQueue();
  obj.Push(x);
  int param_2 = obj.Pop();
  int param_3 = obj.Peek();
  bool param_4 = obj.Empty();
 */