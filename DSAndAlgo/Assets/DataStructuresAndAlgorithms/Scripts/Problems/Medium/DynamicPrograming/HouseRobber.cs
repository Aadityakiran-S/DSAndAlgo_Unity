using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HouseRobber : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/house-robber/

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

	public int Rob(int[] nums)
	{
		int rob1 = 0, rob2 = 0;

		foreach (var num in nums)
		{
			var temp = Math.Max(num + rob1, rob2);
			rob1 = rob2;
			rob2 = temp;
		}

		return rob2;
	}

	#endregion

	#region Helper Methods	



	#endregion
}