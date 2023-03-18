using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinInRotatedSortedArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

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

	public int FindMin(int[] nums)
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

	#endregion

	#region Helper Methods	



	#endregion
}