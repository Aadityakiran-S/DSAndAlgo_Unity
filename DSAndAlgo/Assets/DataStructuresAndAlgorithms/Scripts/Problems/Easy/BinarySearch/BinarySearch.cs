using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearch : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/binary-search/

    #endregion

    #region Methods		

    public int Search_1(int[] nums, int target)
    {
        int left = 0; int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (int)Math.Floor((double)(left + right) / 2);

            if (nums[mid] == target)
                return mid;

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
        }

        return -1;
    }

    public int Search_2(int[] nums, int target)
    {
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;

            if (nums[m] == target)
            {
                return m;
            }
            else if (nums[m] > target)
            {
                r = m;
            }
            else if (nums[m] < target)
            {
                l = m + 1;
            }
        }
        return (nums[l] == target) ? l : -1;
    }

    #endregion
}