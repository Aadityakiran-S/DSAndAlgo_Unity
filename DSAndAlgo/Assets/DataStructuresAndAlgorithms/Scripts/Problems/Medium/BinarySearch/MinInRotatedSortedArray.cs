using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinInRotatedSortedArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

	#endregion


	#region Methods	

	public int FindMin_1(int[] nums)
	{

		int left = 0, right = nums.Length - 1; int result = nums[0];

		while (left <= right)
		{

			//Reached a sorted section of array => the left most is the result
			if (nums[left] <= nums[right])
			{
				result = nums[left];
				return result;
			}

			int mid = (left + right) / 2;

			if (nums[mid] >= nums[left])
			{
				//Search right 
				left = mid + 1;
			}
			else
			{
				//Search left
				right = mid;
			}
		}
		//Just adding to keep syntax correct.
		//The code will run to completion in the while loop itself
		//Since it's given that all values are unique
		return 0;
	}

	public int FindMin_2(int[] nums)
	{
		int l = 0; int r = nums.Length - 1;
		while (nums[l] > nums[r])
		{
			int m = l + (r - l) / 2;

			//Split occured btw l and r
			if (nums[l] > nums[r])
			{
				//Split occured before mid
				if (nums[m] < nums[r])
				{
					r = m;
				}
				//Split occured after mid
				else l = m + 1;
			}
		}

		return nums[l];
	}

	#endregion
}