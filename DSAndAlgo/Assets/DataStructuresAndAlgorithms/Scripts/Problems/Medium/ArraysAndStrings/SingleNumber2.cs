using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SingleNumber2 : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/single-number-ii/description

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

	#region Sorting Solution

	public int SingleNumber_Sorting(int[] nums)
	{
		if (nums.Length == 1)
		{
			return nums[0];
		}

		Array.Sort(nums);
		//After sorting 2 edge cases are there => unique element at the beginning or end of input array
		if (nums[0] != nums[1])
		{
			return nums[0];
		}
		else if (nums[nums.Length - 1] != nums[nums.Length - 2])
		{
			return nums[nums.Length - 1];
		}

		for (int i = 1; i < nums.Length; i += 3)
		{
			if (nums[i - 1] != nums[i])
			{
				return nums[i - 1];
			}
			else
			{
				continue;
			}
		}

		return 0;
	}

	#endregion

	#region HashMap Solution

	public int SingleNumber(int[] nums)
	{
		Dictionary<int, int> dict = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++)
		{
			if (!dict.ContainsKey(nums[i]))
			{
				dict.Add(nums[i], 1);
			}
			else
			{
				dict[nums[i]] += 1;
			}
		}

		foreach (var entry in dict)
		{
			if (entry.Value == 1)
			{
				return entry.Key;
			}
		}

		return 0;
	}

	#endregion
}