using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InsertionSort_Implementation : MonoBehaviour
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

        InsertionSort(_arrayToSort);

        Debug.LogWarning("Is array finally sorted? " + CommonMethodsAndData.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));
    }

    #endregion

    #region Methods

    private void InsertionSort(int[] arrayToSort) //If list is very small or data is almost sorted can be O(n)
    {
        if(CommonMethodsAndData.CheckIfArrayIsSorted(arrayToSort, arrayToSort.Length))
        {
            Debug.Log("Array is already sorted bro");
            return;
        }

        int k;
        for (int i = 0; i < arrayToSort.Length - 1; i++)
        {
            k = i;
            while (k >= 0)
            {
                if (arrayToSort[k] > arrayToSort[k + 1])
                    CommonMethodsAndData.SwapElementsInArray(arrayToSort, k, k + 1);

                k--;
            }
        }
    }

    #endregion
}