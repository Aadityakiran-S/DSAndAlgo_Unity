using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KthLargestIntegerInArray : MonoBehaviour
{
    #region Question
    //Link: https://leetcode.com/problems/kth-largest-element-in-an-array/
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
    [SerializeField] private int _kValue;

    [SerializeField] private int _kthLargestResult;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {

    }

    #endregion

    #region Methods

    public int FindKthLargest_QuickSelect(int[] nums, int k)
    {
        return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
    }

    public int FindKthLargest_QuickSort(int[] nums, int k)
    {
        QuickSort(nums, 0, nums.Length - 1);
        return nums[nums.Length - k];
    }

    //public int FindKthLargest_PriorityQueue(int[] nums, int k)
    //{
    //    PriorityQueue<int, int> minHeap = new(); //By default minHeap behaviour

    //    //Dump everything into PQ but when elements cross k count, just pop the least one out
    //    foreach (int num in nums)
    //    {
    //        minHeap.Enqueue(num, num);
    //        if (minHeap.Count > k)
    //        {
    //            minHeap.Dequeue();
    //        }
    //    }

    //    return minHeap.Peek();
    //}

    #endregion

    #region Auxilliary Functions

    private void QuickSort(int[] nums, int l, int r)
    {
        //Base case
        if (l >= r)
        {
            return;
        }

        int pivot = nums[r]; int p = l;

        for (int i = l; i < r; i++)
        {
            if (nums[i] <= pivot)
            {
                Swap(nums, i, p);
                p++;
            }
        }
        Swap(nums, p, r);

        QuickSort(nums, p + 1, r);
        QuickSort(nums, l, p - 1);
    }

    private int QuickSelect(int[] nums, int l, int r, int k)
    {
        int pivot = nums[r]; int p = l;

        //Finding partition by finding right place for pivot (r)
        for (int i = l; i < r; i++)
        {
            if (nums[i] <= pivot)
            {
                Swap(nums, i, p);
                p++;
            }
        }
        Swap(nums, p, r); //Swapping pivot with currnt position of p

        //Partition further to right
        if (k > p)
        {
            return QuickSelect(nums, p + 1, r, k);
        }
        //Partitin further to left
        else if (k < p)
        {
            return QuickSelect(nums, l, p - 1, k);
        }
        //Partition reached
        else
        {
            return nums[p];
        }
    }

    void Swap(int[] input, int i, int j)
    {
        int I = input[i]; int J = input[j];

        input[i] = J; input[j] = I;
    }

    #endregion
}
