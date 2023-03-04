using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class StartAndEndOfTarget : MonoBehaviour
{
    #region Question
    //Link: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    //Given an array of integers nums sorted in non-decreasing order,
    //find the starting and ending position of a given target value.

    //If target is not found in the array, return [-1, -1].

    //You must write an algorithm with O(log n) runtime complexity.

    //Example 1:
    //Input: nums = [5, 7, 7, 8, 8, 10], target = 8
    //Output: [3,4]

    //Example 2:
    //Input: nums = [5, 7, 7, 8, 8, 10], target = 6
    //Output: [-1,-1]

    //Example 3:
    //Input: nums = [], target = 0
    //Output: [-1,-1]


    //Constraints:
    //0 <= nums.length <= 105
    //-109 <= nums[i] <= 109
    //nums is a non-decreasing array.
    //-109 <= target <= 109
    #endregion

    #region References

    [SerializeField] private int[] _inputArray;
    [SerializeField] private int _numToFind;

    [Space(10)]
    [SerializeField] private int _foundIndex;
    [SerializeField] private int[] _rangeOfFound;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        _foundIndex = BinarySearch_Iterative(_inputArray, _numToFind);
        _rangeOfFound = SearchRange_Optimal(_inputArray, _numToFind);
    }

    #endregion

    #region Methods	

    private int[] SearchRange_Optimal(int[] nums, int target)
    {
        int[] rangeArray = new int[2] { -1, -1 };

        //Condition if nums is empty
        if (nums.Length == 0)
            return rangeArray;

        int foundIndex = BinarySearch_Recursive(nums, target, 0, nums.Length - 1);

        if (foundIndex == -1) //Didn't find what we searched for? Return the default rangeArray
        {
            return rangeArray;
        }
        else //Found what we searched for? Do binary search on both sides of found index to find start and end
        {
            int tempL = foundIndex; int tempR = foundIndex;

            while (true) //Binary search in right side
            {
                int rightResult = BinarySearch_Recursive(nums, target, tempR + 1, nums.Length - 1);

                if (rightResult == -1)
                    break;
                else
                    tempR = rightResult;
            }

            while (true) //Binary search on left side
            {
                int leftResult = BinarySearch_Recursive(nums, target, 0, tempL - 1);

                if (leftResult == -1)
                    break;
                else
                    tempL = leftResult;
            }

            rangeArray = new int[] { tempL, tempR };

            return rangeArray;
        }
    }

    private int[] SearchRange_SubOptimal(int[] nums, int target)
    {
        int[] rangeArray = new int[2] { -1, -1 };

        //Condition if nums is empty
        if (nums.Length == 0)
            return rangeArray;

        int l = 0; int r = nums.Length - 1;
        int m; int value;

        while (l <= r)
        {
            m = (int)Math.Floor((double)(l + r) / 2);
            value = nums[m];

            if (value == target)
            {
                rangeArray = PopulateRangeArray(nums, m);
                return rangeArray;
            }
            else if (target > value)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return rangeArray;
    }

    #endregion

    #region Auxilliary Methods

    int[] PopulateRangeArray(int[] nums, int targetIndex)
    {
        int[] rangeArray = new int[2];
        int value = nums[targetIndex]; int i = targetIndex;

        //Iterate back to first occurance of value
        while (i >= 0)
        {
            if (nums[i] == value)
                i--;
            else
                break;
        }

        i += 1; rangeArray[0] = i;

        while (i < nums.Length)
        {
            if (nums[i] == value)
                i++;
            else
                break;
        }

        i -= 1; rangeArray[1] = i;

        return rangeArray;
    }

    //Return index if exists o/w return -1
    int BinarySearch_Recursive(int[] nums, int target, int l, int r)
    {
        //Overshoot check
        if (l > r || l < 0 || l > nums.Length - 1 || r < 0 || r > nums.Length - 1)
            return -1;

        //End condition for recursion 
        int m = (int)Math.Floor((double)(l + r) / 2);
        if (m == l || m == r) //Only 2 elements remain to be checked l and r
        {
            if (nums[l] == target)
                return l;
            else if (nums[r] == target)
                return r;
            else
                return -1;
        }

        if (target > nums[m])
        {
            l = m;
            return BinarySearch_Recursive(nums, target, l, r);
        }
        else if (target < nums[m])
        {
            r = m;
            return BinarySearch_Recursive(nums, target, l, r);
        }
        else
        {
            return m;
        }
    }

    int BinarySearch_Iterative(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1; int k;

        while (l <= r)
        {
            k = (int)Math.Floor((double)(l + r) / 2);

            if (nums[k] == target) //Found target
            {
                return k;
            }
            else if (nums[k] > target) //target is to left of middle
            {
                r = k - 1;
            }
            else //Target is to the right of middle
            {
                l = k + 1;
            }
        }

        return -1;
    }

    #endregion
}