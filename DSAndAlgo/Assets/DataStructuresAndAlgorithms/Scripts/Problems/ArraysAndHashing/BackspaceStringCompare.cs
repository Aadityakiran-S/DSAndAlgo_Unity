using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BackspaceStringCompare : MonoBehaviour
{
    #region Question
    //Given two strings s and t, return true if they are equal when both are typed into empty text editors.
    //'#' means a backspace character.
    //Note that after backspacing an empty text, the text will continue empty.

    //Example 1:

    //Input: s = "ab#c", t = "ad#c"
    //Output: true
    //Explanation: Both s and t become "ac".
    //Example 2:

    //Input: s = "ab##", t = "c#d#"
    //Output: true
    //Explanation: Both s and t become "".
    //Example 3:

    //Input: s = "a#c", t = "b"
    //Output: false
    //Explanation: s becomes "c" while t becomes "b".

    //Constraints:

    //1 <= s.length, t.length <= 200
    //s and t only contain lowercase letters and '#' characters.


    //Follow up: Can you solve it in O(n) time and O(1) space?
    #endregion

    #region References

    [SerializeField] private string _firstString;
    [SerializeField] private string _secondString;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        Debug.Log("Are the strings equal after typing? " + BackSpaceCompare_Optimized(_firstString, _secondString));
        //Debug.Log("Are both strings equal? " + TestCompare(_firstString, _secondString));
    }

    #endregion

    #region Methods

    public bool BackspaceCompare(string s, string t) //T: n; S: n
    {
        //Initializing stacks to store char
        Stack<char> sStack = new Stack<char>(); //O(n) : Space
        Stack<char> tStack = new Stack<char>();

        //Populating stacks with results after considering #
        foreach (char c in s)   //O(n)
        {
            if (c == '#')
            {
                if (sStack.Count != 0)
                {
                    sStack.Pop();
                }
            }
            else
            {
                sStack.Push(c);
            }
        }

        foreach (char c in t)   //O(n)
        {
            if (c == '#')
            {
                if (tStack.Count != 0)
                {
                    tStack.Pop();
                }
            }
            else
            {
                tStack.Push(c);
            }
        }

        //Comparing stacks
        if (sStack.Count != tStack.Count) //Same result => Same length
        {
            return false;
        }
        //Popping each element and comparing (essentially comparing output in reverse)
        else //Length is same
        {
            if (sStack.Count == 0)   //Both stacks have nothing in them, ie: result in both are empty str
            {
                return true;
            }

            int iterationCount = sStack.Count;
            for (int i = 0; i < iterationCount; i++)    //O(n)
            {
                if (sStack.Pop() != tStack.Pop())
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool BackSpaceCompare_Optimized(string s, string t) //T: n; S: 1
    {
        s = BackspaceResult(s);
        t = BackspaceResult(t);

        return (s == t); //Return comparison after pruning
    }

    #endregion

    #region Helper Functions

    string BackspaceResult(string s)
    {
        int p = 0; int count = s.Length;
        for (int i = 0; i < count; i++) //Pruning s
        {
            //Pruning string
            if (s[p] == '#')
            {
                if (p - 1 >= 0) //Going 2 steps back and pruning
                {
                    s = s.Remove(p - 1, 2);
                    p -= 2;
                }
                else //Just removing the #
                {
                    s = s.Remove(p, 1);
                    p -= 1;
                }
            }
            p += 1;
        }

        return s;
    }

    bool TestCompare(string s, string t)
    {
        return s == t;
    }

    #endregion
}