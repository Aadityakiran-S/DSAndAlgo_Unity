using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QuickSort_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] private int[] _arrayToSort;

    #endregion

    #region UnityLifecycle
    private void Awake()
    {
        //_arrayToSort = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 }; //I'm just adding this in the inspector
    }

    private void Start()
    {
        Debug.LogWarning("Is array initialy sorted? " + CommonMethodsAndData.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));

        QuickSort(_arrayToSort, 0, _arrayToSort.Length - 1);

        Debug.LogWarning("Is array finally sorted? " + CommonMethodsAndData.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));
    }

    #endregion

    #region Methods

    private void QuickSort(int[] inputArray, int left, int right)
    {
        //Exit condition: Left should always be greater than right. If they are same also no need to sort
        if (left >= right) return;

        //Pivoting off the extreme right value
        int pivotIndex = right, i = left, j = left;

        while (j < pivotIndex)
        {
            //Iterating and putting all things left of eventual pivot's position less than it and
            if (inputArray[j] >= inputArray[pivotIndex])
            {
                j++;
            }
            else //Everything to the right greater than it.
            {
                Swap(i, j, inputArray);
                i++; j++;
            }
        }

        Swap(i, pivotIndex, inputArray); //Swapping i with end to put pivot in it's final place

        //Calling quick sort on each sub array
        QuickSort(inputArray, left, i - 1); //Left sub array
        QuickSort(inputArray, i + 1, right); //Right sub array
    }

    #endregion

    #region Auxilliary functions

    void Swap(int i, int j, int[] input)
    {
        int I = input[i]; int J = input[j];

        input[i] = J; input[j] = I;
    }

    #endregion
}