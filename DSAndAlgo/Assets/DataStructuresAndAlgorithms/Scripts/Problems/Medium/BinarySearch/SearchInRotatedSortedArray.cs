using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchInRotatedSortedArray : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/search-in-rotated-sorted-array/

    #endregion

    #region Methods		

    public int Search_1(int[] nums, int target)
    {
        int left = 0; int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (target == nums[mid])
            {
                return mid;
            }

            //If left half of array is sorted
            if (nums[left] <= nums[mid])
            {
                //If target is within the sorted range
                if (target >= nums[left] && target <= nums[mid])
                {
                    right = mid - 1;
                }
                else left = mid + 1; //Target is not within the sorted range
            }
            else//Right half is sorted
            {
                //Target is within the sorted range
                if (target <= nums[right] && target >= nums[mid])
                {
                    left = mid + 1;
                }
                else right = mid - 1; //Target is not within the sorted range
            }
        }
        //At this point, left and right conincide (left == right)
        //So, either target is here or DNE in array
        return -1;
    }

    public int Search_2(int[] nums, int target)
    {
        int left = 0; int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (target == nums[mid])
            {
                return mid;
            }

            //If left half of array is sorted
            if (nums[left] <= nums[mid])
            {
                //If target is within the sorted range
                if (target >= nums[left] && target <= nums[mid])
                {
                    right = mid;
                }
                else left = mid + 1; //Target is not within the sorted range
            }
            else//Right half is sorted
            {
                //Target is within the sorted range
                if (target <= nums[right] && target >= nums[mid])
                {
                    left = mid + 1;
                }
                else right = mid; //Target is not within the sorted range
            }
        }
        //At this point, left and right conincide (left == right)
        //So, either target is here or DNE in array
        return (target == nums[left]) ? left : -1;
    }

    #endregion
}