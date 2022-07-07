using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BubbleSort_Implementation : MonoBehaviour
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
        Debug.LogWarning("Is array initialy sorted? " + CommonMethods.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));

        BubbleSort1(_arrayToSort);

        Debug.LogWarning("Is array finally sorted? " + CommonMethods.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));
    }

    #endregion

    #region Methods

    //TODO: Find out where this is running an infinite loop
    private void BubbleSort1(int[] arrayToSort)
    {
        //0 or 1 element => no need to sort
        if (arrayToSort.Length < 2) return;

        bool isSorted = false; int i = 0;
        while (!isSorted)
        {
            //Interchange elements if not sorted
            if (arrayToSort[i] > arrayToSort[i + 1])
            {
                CommonMethods.SwapElementsInArray(arrayToSort, i, i + 1);
            }

            i++;    //Incrementing after we've checked one block

            //We've reached the end of the array in the last if statement
            if (i == arrayToSort.Length - 1) 
            {
                //reset and check if sorted after current pass
                i = 0; isSorted = CommonMethods.CheckIfArrayIsSorted(arrayToSort, arrayToSort.Length);
            }
        }
    }

    private void BubbleSort2(int[] arrayToSort)
    {
        int k = 1;
        for (int i = 0; i < arrayToSort.Length - k; i++)
        {
            for (int j = 0; j < arrayToSort.Length - 1; j++)
            {
                if(arrayToSort[j] > arrayToSort[j + 1])
                {
                    CommonMethods.SwapElementsInArray(arrayToSort, i, i + 1);
                }
            }
            k++;
        }
    }

    #endregion
}