using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinStack
{
    #region Question

    //https://leetcode.com/problems/min-stack/description/

    #endregion

    #region References and Constructor

    private int _min;
    private Stack<int[]> _stack;

    public MinStack()
    {
        _stack = new Stack<int[]>();
    }

    #endregion

    #region Methods

    public void Push(int val)
    {
        //If value is less than min => update
        if (_stack.Count == 0 || val <= _min)
        {
            _min = val;
        }

        int[] temp = new int[] { val, _min };
        _stack.Push(temp);
    }

    //Somehow pop doesn't return any value here
    public void Pop()
    {
        _stack.Pop();

        //Updating min if the current popped element is min.
        if (_stack.Count != 0)
        {
            int[] nextElement = _stack.Peek();
            _min = nextElement[1];
        }
    }

    public int Top()
    {
        return _stack.Peek()[0];
    }

    public int GetMin()
    {
        return _min;
    }

    #endregion
}