using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchInsertPosition : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/search-insert-position/description/	

	#endregion		
	
	#region Methods		
	
	public int SearchInsert_1(int[] nums, int target)
    {
        int i = 0; int j = nums.Length - 1;
        while (i <= j)
        {
            //Method to find mid without overflow
            int m = i + (j - i) / 2;

            //Exit if target is in range
            if (nums[m] == target)
            {
                return m;
            }

            //We've reached the end of Binary search but still target is not found
            // => target DNE in array
            if (i == j)
            {
                if (target < nums[m])
                {
                    return m;
                }
                else if (target > nums[m])
                {
                    return m + 1;
                }
            }
            //Regular binary search
            else if (target < nums[m])
            {
                j = m;
            }
            else if (target > nums[m])
            {
                i = m + 1;
            }
        }

        return 0;
    }

    public int SearchInsert_2(int[] nums, int target)
    {
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            //Method to find mid without overflow
            int m = l + (r - l) / 2;

            //Exit if target is in range
            if (nums[m] == target)
            {
                return m;
            }
            //Regular binary search
            else if (target < nums[m])
            {
                r = m;
            }
            else if (target > nums[m])
            {
                l = m + 1;
            }
        }

        //At this point, 
        // l = r; target is either at this position or DNE in nums
        return (target <= nums[l]) ? l : l + 1;
        //If target is at this position or less than whatever is here 
        //this is the index where it is or should be if replaced.
        //If target is greater than what is at this position
        //If it's introduced, it should be one greater than l in index
    }

    #endregion
}