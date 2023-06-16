using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchInRotatedSortedArrayII : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/

    #endregion

    #region Methods

    public bool Search_2(int[] nums, int target)
    {
        int left = 0; int right = nums.Length - 1;

        //Linear search until we reach pivot
        while (left < right && nums[left] <= nums[left + 1])
        {
            if (nums[left] == target)
            {
                return true;
            }
            else left++;
        }

        //After performing linear search, if pivot element itself is target
        if (left < nums.Length && nums[left] == target)
        {
            return true;
        }

        left++; //Shifting left to point of inflection, this making left to right a sorted section

        //Reached pivot? Do Binary search
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return true;
            }

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return false;
    }

    public bool Search_1(int[] nums, int target)
    {
        int left = 0; int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                return true;
            }

            //In this case, binary search is not helpful 
            //(cannot determine which section pivot/target belongs)
            if (nums[left] == nums[mid])
            {
                left++; continue;
            }

            bool isTargetInLeft = (nums[left] <= target);
            bool isPivotInLeft = (nums[left] <= nums[mid]);

            if (isTargetInLeft ^ isPivotInLeft)
            {
                if (isTargetInLeft)
                { //Target in left? then search left
                    right = mid - 1;
                }
                else left = mid + 1; //Target in right? then search right
            }
            //Target and mid in same sorted array => regular binary search
            else
            {
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else right = mid - 1;
            }
        }

        return false;
    }

    #endregion
}