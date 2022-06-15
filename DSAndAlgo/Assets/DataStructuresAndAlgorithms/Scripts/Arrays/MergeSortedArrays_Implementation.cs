using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class MergeSortedArrays_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] private int[] _array1;
    [SerializeField] private int[] _array2;

    private int[] _mergedArray;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _mergedArray = new int[_array1.Length + _array2.Length];
    }

    private void Start()
    {
        _mergedArray = MergeSortedArrays(_array1, _array2);
    }

    #endregion

    #region Methods

    public int[] SimpleAndAbstractMethod_MergeSortedArray(int[] array1, int[] array2)
    {
        Array.Sort(array1); Array.Sort(array2);

        int[] mergedArray = array1.Concat(array2).ToArray();
        Array.Sort(mergedArray);
        if (mergedArray.Length != 0)
        {
            return mergedArray;
        }
        else
            return default;
    }

    public int[] MergeSortedArrays(int[] array1, int[] array2)
    {
        int[] mergedArray = new int[array1.Length + array2.Length];
        int n = array1.Length, m = array2.Length;
        int i = 0, j = 0, k = 0;

        //If not sorted, sort them up or return not sorted
        if (ArraySortedOrNot(array1, array1.Length) == 0)
            Array.Sort(array1);
        if (ArraySortedOrNot(array2, array2.Length) == 0)
            Array.Sort(array2);

        //If either of the arrays are empty, return them concacted
        if (n == 0 || m == 0)
        {
            mergedArray = array1.Concat(array2).ToArray();
            return mergedArray;
        }

        while (i < n && j < m)
        {
            //if one element is greater than the other, put the greater one in and increment THAT index
            if (array1[i] > array2[j])
            {
                mergedArray[k] = array2[j];
                j++; k++;
            }
            else if (array1[i] < array2[j])
            {
                mergedArray[k] = array1[i];
                i++; k++;
            }
            //if they're equal, put either one in and increment both indices
            else if (array1[i] == array2[j])
            {
                mergedArray[k] = array1[i];
                k++;
                mergedArray[k] = array2[j];
                i++; j++; k++;
            }
        }

        //Completely finished one array? Concact the rest of the other
        if (i == n)
        {
            while (j < m)
            {
                mergedArray[k] = array2[j];
                j++; k++;
            }
        }
        else if (j == m)
        {
            while (i < n)
            {
                mergedArray[k] = array2[i];
                i++; k++;
            }
        }

        return mergedArray;
    }

    #endregion

    #region Helper Methods

    static int ArraySortedOrNot(int[] array, int lengthOfArray)
    {
        // Array has one or no element or the
        // rest are already checked and approved.
        if (lengthOfArray == 1 || lengthOfArray == 0)
            return 1;

        // Unsorted pair found (Equal values allowed)
        if (array[lengthOfArray - 1] < array[lengthOfArray - 2])
            return 0;

        // Last pair was sorted
        // Keep on checking
        return ArraySortedOrNot(array, lengthOfArray - 1);
    }

    #endregion
}
