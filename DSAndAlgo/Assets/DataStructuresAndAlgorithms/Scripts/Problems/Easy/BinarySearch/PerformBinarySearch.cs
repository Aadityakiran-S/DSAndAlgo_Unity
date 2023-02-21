using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PerformBinarySearch : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/binary-search/description/

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
		int left = 0; int right = nums.Length - 1;

		//Performing search till left and right cross
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

	#endregion

	#region Helper Methods	



	#endregion
}