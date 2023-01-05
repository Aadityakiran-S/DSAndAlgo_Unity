using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TwoSum2 : MonoBehaviour
{
	#region Question
	//Link: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
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
	public int[] TwoSum(int[] numbers, int target)
	{
		int[] output = new int[2];
		int i = 0; int j = numbers.Length - 1;

		while (i < j)
		{
			if (numbers[i] + numbers[j] < target)
			{
				i++;
			}
			else if (numbers[i] + numbers[j] > target)
			{
				j--;
			}
			else
			{
				output = new int[] { i + 1, j + 1 };
				break;
			}
		}

		return output;
	}


	#endregion
}