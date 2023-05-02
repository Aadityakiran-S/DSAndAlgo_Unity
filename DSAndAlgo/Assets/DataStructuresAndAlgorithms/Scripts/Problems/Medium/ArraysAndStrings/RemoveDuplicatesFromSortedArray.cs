using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RemoveDuplicatesFromSortedArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/

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

	public int RemoveDuplicates(int[] nums)
	{
		int i = 1;

		foreach (int n in nums)
		{
			if (nums[i - 1] != n) nums[i++] = n;
		}

		return i;
	}

	#endregion

}