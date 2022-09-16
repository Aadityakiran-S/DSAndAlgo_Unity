using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ValidParentheses : MonoBehaviour
{
    #region Question
    //Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    //An input string is valid if:
    //Open brackets must be closed by the same type of brackets.
    //Open brackets must be closed in the correct order.

    //Example 1:

    //Input: s = "()"
    //Output: true
    //Example 2:

    //Input: s = "()[]{}"
    //Output: true
    //Example 3:

    //Input: s = "(]"
    //Output: false


    //Constraints:

    //1 <= s.length <= 104
    //s consists of parentheses only '()[]{}'.
    #endregion

    #region References

    #endregion

    #region UnityLifecycle

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    #endregion

    #region Methods

    public bool IsValid(string s)
    {
        //No Paranthesis is still valid paranthesis
        if (s.Length == 0)
        {
            return true;
        }
        //Odd length string cannot close. Brackets should always come in pairs
        else if ((s.Length) % 2 != 0)
        {
            return false;
        }

        Dictionary<char, char> correctBracketPairs = new Dictionary<char, char>
        {
            { '}', '{' },
            { ']', '[' },
            { ')', '(' }
        };

        Stack<char> charStack = new Stack<char>();

        foreach (char c in s)
        {
            //Condition to push into stack: Will be one of the values in the dict (Left bracket)
            if (!correctBracketPairs.ContainsKey(c))
            {
                charStack.Push(c);
            }
            //The other alternative is if c is a closing parenthesis of some sort
            else //Then we push out of stack and compare 
            {
                //Nothing to pop out to compare => unbalanced paranthesis
                if (charStack.Count == 0)
                {
                    return false;
                }
                //Not empty => Something to compare
                else
                {
                    char correspondingBracket = charStack.Pop();
                    char correctBracket = correctBracketPairs[c];

                    //Not correct bracket that is closed
                    if (correspondingBracket != correctBracket)
                    {
                        return false;
                    }
                }
            }
        }

        //If everything cancels out then charStack should be empty otherwise it's unbalanced
        return (charStack.Count == 0);
    }

    public bool IsValid_WithoutStack(string s)
    {
        return default;
    }

    #endregion
}