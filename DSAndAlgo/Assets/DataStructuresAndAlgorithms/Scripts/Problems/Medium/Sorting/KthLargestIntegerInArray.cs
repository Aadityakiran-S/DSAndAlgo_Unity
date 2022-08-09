using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KthLargestIntegerInArray : MonoBehaviour
{
    #region Question
    //Given an integer array nums and an integer k, return the kth largest element in the array.
    //Note that it is the kth largest element in the sorted order, not the kth distinct element.

    //You must solve it in O(n) time complexity.

    //Example 1:
    //Input: nums = [3, 2, 1, 5, 6, 4], k = 2
    //Output: 5

    //Example 2:
    //Input: nums = [3, 2, 3, 1, 2, 4, 5, 5, 6], k = 4
    //Output: 4

    //Constraints:
    //1 <= k <= nums.length <= 105
    //-104 <= nums[i] <= 104
    #endregion

    #region References

    [SerializeField] private int[] _inputArray;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        QuickSort(_inputArray, 0, _inputArray.Length - 1);
    }

    #endregion

    #region Methods	

    private int FindKthLargest(int[] nums, int k)
    {
        return 0;
    }

    #endregion

    #region Auxilliary Functions

    void QuickSort(int[] inputArray, int left, int right)
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

    void Swap(int i, int j, int[] input)
    {
        int I = input[i]; int J = input[j];

        input[i] = J; input[j] = I;
    }

    #endregion
}
