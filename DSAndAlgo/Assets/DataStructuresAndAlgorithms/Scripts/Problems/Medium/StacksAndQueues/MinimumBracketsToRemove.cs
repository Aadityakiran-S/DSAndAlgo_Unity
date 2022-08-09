using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinimumBracketsToRemove : MonoBehaviour
{
    #region Question
    //Link: https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/

    //Given a string s of '(' , ')' and lowercase English characters.
    //Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions)
    //so that the resulting parentheses string is valid and return any valid string.	

    //Formally, a parentheses string is valid if and only if:
    //It is the empty string, contains only lowercase characters, or
    //It can be written as AB(A concatenated with B), where A and B are valid strings, or
    //It can be written as (A), where A is a valid string.


    //Example 1:

    //Input: s = "lee(t(c)o)de)"
    //Output: "lee(t(c)o)de"
    //Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.

    //Example 2:

    //Input: s = "a)b(c)d"
    //Output: "ab(c)d"

    //Example 3:

    //Input: s = "))(("
    //Output: ""
    //Explanation: An empty string is also valid.



    //Constraints:

    //1 <= s.length <= 105
    //s[i] is either'(' , ')', or lowercase English letter.

    #endregion

    #region References

    [SerializeField] private string _inputString;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        //Debug.Log("After removing " + _inputString.Remove(1));

        Debug.Log("Min brackets removed output is: " + MinRemoveToMakeValid(_inputString));
    }

    #endregion

    #region Methods	
    private string MinRemoveToMakeValid(string s) //S:n, T:n
    {
        //Empty strings are perfectly valid
        if (s.Length == 0) return s;

        Stack<int> leftStack = new Stack<int>();
        Stack<int> rightStack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            //If encountered a left, push it's index to left stack
            if (s[i] == '(')
            {
                leftStack.Push(i);
            }
            //If found right, two options
            else if (s[i] == ')')
            {
                if (leftStack.Count != 0) //Balance with left if possible
                {
                    leftStack.Pop();
                }
                else //Otherwise, simply add to unbalanced right
                {
                    rightStack.Push(i);
                }
            }
        }

        while(leftStack.Count != 0)
        {
            s = s.Remove(leftStack.Pop(), 1);
        }

        while(rightStack.Count != 0)
        {
            s = s.Remove(rightStack.Pop(), 1);
        }

        return s;
    }

    #endregion
}