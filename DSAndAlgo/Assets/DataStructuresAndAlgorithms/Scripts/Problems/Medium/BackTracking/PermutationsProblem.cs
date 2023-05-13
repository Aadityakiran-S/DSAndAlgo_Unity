using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PermutationsProblem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/permutations/

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

	public IList<IList<int>> Permute(int[] nums)
	{
		IList<IList<int>> result = new List<IList<int>>();
		PermuteHelper(nums, 0, result);
		return result;
	}

	private void PermuteHelper(int[] nums, int start, IList<IList<int>> result)
	{
		if (start == nums.Length - 1)
		{
			List<int> permutation = new List<int>(nums);
			result.Add(permutation);
			return;
		}

		for (int i = start; i < nums.Length; i++)
		{
			(nums[i], nums[start]) = (nums[start], nums[i]);
			PermuteHelper(nums, start + 1, result);
			(nums[i], nums[start]) = (nums[start], nums[i]); // backtrack
		}
	}

	#endregion

}