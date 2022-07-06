using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MergeSort_Implementation : MonoBehaviour
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

        MergeSort(_arrayToSort);

        Debug.LogWarning("Is array finally sorted? " + CommonMethods.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));
    }

    #endregion

    #region Methods

    private void MergeSort(int[] arrayToSort) //Among the top 2 best algos for sorting
    {

    }

    #endregion
}