using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Factorial : MonoBehaviour
{
    #region References

    [SerializeField] private int _findFactorialOf;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        Debug.Log("Factorial of " + _findFactorialOf + " is " + FindFactorial_Recursive(_findFactorialOf));
    }

    #endregion


    #region PrivateMethods

    private int FindFactorial_Recursive(int num)
    {
        #region Error check
        if (num < 0)
        {
            Debug.LogError("You can't find the factorial of a negative number, \n didn't you learn math in school?");
            return default;
        }
        else if (num == 0 || num == 1)
        {
            return 1;
        }
        #endregion

        if (num == 2)   //Base case
        {
            return 2;
        }
        else
        {
            return num * FindFactorial_Recursive(num - 1);  //num-- won't work for some reason
        }
    }

    private int FindFactorial_Iterative(int num)
    {
        #region Error Check
        if (num < 0)
        {
            Debug.LogError("You can't find the factorial of a negative number, \n didn't you learn math in school?");
            return default;
        }
        else if (num == 0 || num == 1)
        {
            return 1;
        }
        #endregion

        int result = num;
        while (num > 1)
        {
            num--;
            result *= num;
        }

        return result;
    }

    #endregion
}