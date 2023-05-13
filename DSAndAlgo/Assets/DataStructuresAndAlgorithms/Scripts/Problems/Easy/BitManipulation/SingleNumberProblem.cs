using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SingleNumberProblem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/single-number/description/

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

	public int SingleNumber(int[] nums)
	{
		int result = 0;

		//Doing XOR between every value in the array leaves us 
		//with the unique elemnt since all other cancel out
		foreach (int num in nums)
		{
			result = num ^ result;
		}

		return result;
	}

	#endregion

	#region Helper Methods	



	#endregion
}