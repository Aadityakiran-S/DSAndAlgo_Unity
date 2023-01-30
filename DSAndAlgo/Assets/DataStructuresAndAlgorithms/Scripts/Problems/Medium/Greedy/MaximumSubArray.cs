using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MaximumSubArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/maximum-subarray/description/

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

	public int MaxSubArray(int[] nums)
	{
		int overallSum = 0; int maxSum = nums[0]; //Have to start with this in case negative only arr is input
		for (int i = 0; i < nums.Length; i++)
		{
			//Ignoring if overall sum turns out to be negative
			overallSum = (overallSum < 0) ? 0 : overallSum;
			overallSum += nums[i]; //In case all entries are negative, max sum is min -ve element
			maxSum = Math.Max(overallSum, maxSum);
		}

		return maxSum;
	}

	#endregion

	#region Helper Methods	



	#endregion
}