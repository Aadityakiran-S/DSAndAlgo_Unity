using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KthLargestInStream : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/kth-largest-element-in-a-stream/

    #endregion

    #region References



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

    #region Using Priority Queue

    ////Priority queue is basically a min heap in C#
    //PriorityQueue<int, int> queue = new();
    //int k;

    //public KthLargest(int k, int[] nums)
    //{
    //    this.k = k;

    //    //Adding all values on instantiate
    //    foreach (int num in nums)
    //    {
    //        Add(num);
    //    }
    //}

    //public int Add(int val)
    //{
    //    //Adding value by default
    //    queue.Enqueue(val, val);

    //    //If value goes beyond a threshold, throw the lowest priority out
    //    //This results in storing only the kth largets elements 
    //    if (queue.Count > k)
    //    {
    //        queue.Dequeue();
    //    }

    //    //Only k largest elements will remain and peek returns min among them
    //    //ie: kth largest itself.
    //    return queue.Peek();
    //}

    #endregion

    #region Sorted Dictionary

    ////Using sorted dictionary which basically acts as a min heap
    //private SortedDictionary<int, int> _minHeap;
    //private int _k;
    ////Keeping track of actual size since it doesn't account for duplicates
    //private int _actualSize = 0;

    //public KthLargest(int k, int[] nums)
    //{
    //    _minHeap = new();
    //    _k = k;

    //    foreach (int num in nums)
    //    {
    //        Add(num);
    //    }

    //}

    //public int Add(int val)
    //{
    //    //Accounting for duplicates
    //    if (_minHeap.ContainsKey(val))
    //    {
    //        _minHeap[val]++;
    //    }
    //    else
    //    {
    //        _minHeap.Add(val, 1);
    //    }
    //    _actualSize++;

    //    //Need to push out min element
    //    if (_actualSize > _k)
    //    {
    //        var minEntry = _minHeap.First();

    //        if (minEntry.Value > 1)
    //        {
    //            _minHeap[minEntry.Key]--;
    //        }
    //        else
    //        {
    //            _minHeap.Remove(minEntry.Key);
    //        }

    //        _actualSize--;
    //    }

    //    return _minHeap.First().Key;
    //}

    #endregion

    #region Bit Manipulation and Binary Search

    //List<int> list;
    //int index, length;

    ////Basically sorting all elements and adding to list    
    //public KthLargest(int k, int[] nums)
    //{
    //    list = new();
    //    index = k; length = nums.Length;
    //    Array.Sort(nums);
    //    list.AddRange(nums.ToList());
    //}

    //public int Add(int val)
    //{
    //    int pos = list.BinarySearch(val);
    //    //If index doesn't exist, then we'll get -ve number
    //    //we just flip the bits of that to find which place we can enter current val in
    //    if (pos < 0)
    //    {
    //        pos = ~pos;
    //    }

    //    //Adding current val in sorted order
    //    list.Insert(pos, val); length++;
    //    return list[length - index];
    //}

    #endregion

    #endregion

    #region Helper Methods	



    #endregion
}