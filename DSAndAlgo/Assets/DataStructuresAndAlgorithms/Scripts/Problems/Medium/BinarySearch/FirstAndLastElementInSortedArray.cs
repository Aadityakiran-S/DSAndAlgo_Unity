using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FirstAndLastElementInSortedArray : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

    #endregion

    #region Method 1	

    public int[] SearchRange_1(int[] nums, int target)
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

    #endregion

    #region Method 2

    public int[] SearchRange_2(int[] nums, int target)
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

    #endregion

    #region Method 3

    public int[] SearchRange(int[] nums, int target)
    {
        int[] output = { -1, -1 };
        if (nums.Length == 0)
        {
            return output;
        }

        //Binary Search till we find target
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;

            //Once target found, find extent of range of target
            if (nums[m] == target)
            {
                output = FindExtentOfRange(nums, m);
                return output;
            }

            if (nums[m] > target)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        //If target only exists once, express range as that
        if (nums[l] == target) output = new int[] { l, l };

        return output; //If DNE, return default value for output
    }

    private int[] FindExtentOfRange(int[] nums, int mid)
    {
        int i = mid; int j = mid;
        while (i >= 0 && nums[i] == nums[mid])
        {
            i--;
        }
        while (j < nums.Length && nums[j] == nums[mid])
        {
            j++;
        }

        return new int[] { i + 1, j - 1 };
    }

    #endregion

}