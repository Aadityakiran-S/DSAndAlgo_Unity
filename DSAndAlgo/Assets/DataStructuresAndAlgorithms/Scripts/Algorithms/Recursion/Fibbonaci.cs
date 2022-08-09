using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Fibbonaci : MonoBehaviour
{
    #region References

    [SerializeField] private int _fibbonaciIndex;

    [Header("Debug values")] [Space(5)]
    [SerializeField] private int _iterativeCount;
    [SerializeField] private int _plainRecursiveCount;
    [SerializeField] private int _DPRecursiveCount;

    #endregion

    #region UnityLifecycle

    private void Awake()
    {
        _plainRecursiveCount = _DPRecursiveCount = 0;
    }

    private void Start()
    {
        Debug.Log("Fibbonaci of " + _fibbonaciIndex + " is " + Fibbonaci_Iterative(_fibbonaciIndex));
        Debug.Log("Fibbonaci of " + _fibbonaciIndex + " is " + Fibbonaci_Recursive(_fibbonaciIndex));
        Debug.Log("Fibbonaci of " + _fibbonaciIndex + " is " + Fibbonaci_Recursive_DP(_fibbonaciIndex));
    }

    #endregion

    #region PrivateMethods

    private int Fibbonaci_Recursive(int fibIndex)
    {
        _plainRecursiveCount++;

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
        return Fibbonaci_Recursive(fibIndex - 1) + Fibbonaci_Recursive(fibIndex - 2);
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
            _iterativeCount++;
            fibList.Add(fibList[i - 2] + fibList[i - 1]);
        }

        return fibList[fibIndex];
    }

    private int Fibbonaci_Recursive_DP(int fibIndex)
    {
        _DPRecursiveCount++;

        //Just an error check for this implementation
        if (fibIndex == 0)
            return 0;
        else if (fibIndex == 1)
            return 1;

        //Declaring and initializing result array
        int[] resultArray = new int[fibIndex + 1];
        for (int i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = -1;
        }

        return Fibbonaci_DP(fibIndex, resultArray);
    }


    #endregion

    #region HelperFunctions

    int Fibbonaci_DP(int fibIndex, int[] resultArray)
    {
        _DPRecursiveCount++;

        if (resultArray[fibIndex] != -1) //Something's there in that place
        {
            return resultArray[fibIndex];
        }
        else
        {
            if (fibIndex == 0)
            {
                return 0;
            }
            else if (fibIndex == 1)
            {
                return 1;
            }
            else
            {
                int result = Fibbonaci_DP(fibIndex - 1, resultArray) + Fibbonaci_DP(fibIndex - 2, resultArray);
                resultArray[fibIndex] = result;

                return result;
            }
        }
    }

    #endregion
}
