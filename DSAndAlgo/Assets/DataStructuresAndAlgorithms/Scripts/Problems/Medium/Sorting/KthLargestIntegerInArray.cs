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

    #region Kth Largest using custom MinHeap implementation

    public int FindKthLargest_MinHeap(int[] nums, int k)
    {
        MinHeap minHeap = new MinHeap();

        //Dump everything into PQ but when elements cross k count, just pop the least one out
        foreach (int num in nums)
        {
            minHeap.Enqueue(num);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }


    #region MinHeap implementation

    public class MinHeap
    {
        #region References and Constructor

        private List<int> _minHeap;
        public int Count => _minHeap.Count;

        public MinHeap()
        {
            _minHeap = new List<int>();
        }

        #endregion

        #region Public functions

        //For debugging purposes
        public void PrintAllValues()
        {
            foreach (int entry in _minHeap)
            {
                Console.WriteLine("entry: " + entry);
            }
        }

        public int Peek()
        {
            return _minHeap[0];
        }

        public void Enqueue(int entry)
        {
            //Taking entry, putting it at the end and taking it's parent
            _minHeap.Add(entry);
            int i = _minHeap.Count - 1; int p = _minHeap[(int)Math.Truncate((float)(i - 1) / 2)];
            //Comparing parents till next parent is less than our entry
            while (p > entry)
            {
                this.Swap(_minHeap, i, (int)Math.Truncate((float)(i - 1) / 2));
                i = (int)Math.Truncate((float)(i - 1) / 2); p = _minHeap[(int)Math.Truncate((float)(i - 1) / 2)];
            }
        }

        public int? Dequeue()
        {
            if (_minHeap.Count == 0)
            {
                return null;
            }

            //Popping first and putting last in it's place
            int output = _minHeap[0]; _minHeap.RemoveAt(0); //Caching and removing first
            int last = _minHeap[_minHeap.Count - 1]; //Displacing last from last to front
            _minHeap.RemoveAt(_minHeap.Count - 1); _minHeap.Insert(0, last);

            int i = 0; //Finding correct place of now brought to front last element
            while (i < _minHeap.Count)
            {
                //Setting kids and their values
                int left = (2 * i) + 1; int right = (2 * i) + 2;
                int? leftValue = null; int? rightValue = null;

                //If kid indices are within bounds, give corresponding values to them
                if (left < _minHeap.Count)
                {
                    leftValue = _minHeap[left];
                }
                if (right < _minHeap.Count)
                {
                    rightValue = _minHeap[right];
                }

                //Set to replace index
                int toReplaceIndex = -1;

                //If both kids are out of bounds, i has already found it's place
                if (leftValue == null && rightValue == null)
                {
                    break;
                }
                //If both are in bounds, need to replace min child (left or right)
                if (leftValue != null && rightValue != null)
                {
                    toReplaceIndex = (leftValue < rightValue) ? left : right;
                }
                //If only one is in bounds, then we need to replace that 
                else
                {
                    toReplaceIndex = (leftValue == null) ? right : left;
                }

                //If child to replace is greater than i, then i has already found it's acutal place
                if (_minHeap[toReplaceIndex] >= _minHeap[i])
                {
                    break;
                }
                //if found appropriate child to replace, we swap with existing
                else
                {
                    Swap(_minHeap, i, toReplaceIndex); i = toReplaceIndex;
                }
            }

            return output;
        }

        #endregion

        #region Helper functions
        private void Swap(List<int> input, int i, int j)
        {
            int iEntry = input[i]; int jEntry = input[j];
            input[i] = jEntry; input[j] = iEntry;
        }
        #endregion
    }

    #endregion
    
    #endregion

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
