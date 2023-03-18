using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FindInRotatedSortedArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/search-in-rotated-sorted-array/

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

	public int Search(int[] nums, int target)
	{
		int low = 0;
		int high = nums.Length - 1;

		while (low <= high)
		{
			var mid = (low + high) / 2;

			if (nums[mid] == target)
			{
				return mid;
			}
			else if (nums[low] <= nums[mid])
			{
				if (target > nums[mid] || target < nums[low])
					low = mid + 1;
				else high = mid - 1;
			}
			else
			{
				if (target < nums[mid] || target > nums[high])
					high = mid - 1;
				else low = mid + 1;
			}
		}

		return -1;
	}

	#endregion

	#region Helper Methods	



	#endregion
}