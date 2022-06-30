using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Fibbonaci : MonoBehaviour
{
    #region References

    [SerializeField] private int _fibbonaciIndex;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        Debug.Log("The " + _fibbonaciIndex + "th number in the Fib series is: " + Fibbonaci_Recursive(_fibbonaciIndex));
    }

    #endregion

    #region PrivateMethods

    private int Fibbonaci_Recursive(int fibIndex)
    {
        #region Error check
        if (fibIndex < 0)
        {
            Debug.LogWarning("Negative indices not allowed");
            return default;
        }
        #endregion

        if (fibIndex == 0)
        {
            return 0;
        }
        else if (fibIndex == 1)
        {
            return 1;
        }

        //Base case
        if (fibIndex == 2)
        {
            return 1;
        }

        //Simply adding the previous 2 numbers
        return Fibbonaci_Recursive(fibIndex -1) + Fibbonaci_Recursive(fibIndex - 2);
    }

    private int Fibbonaci_Iterative(int fibIndex)
    {
        #region Error check
        if (fibIndex < 0)
        {
            Debug.LogWarning("Negative indices not allowed");
            return default;
        }
        #endregion

        List<int> fibList = new List<int> { 0, 1 };

        for (int i = 2; i < fibIndex + 1; i++)
        {
            fibList.Add(fibList[i - 2] + fibList[i - 1]);
        }

        return fibList[fibIndex];
    }


    #endregion
}
