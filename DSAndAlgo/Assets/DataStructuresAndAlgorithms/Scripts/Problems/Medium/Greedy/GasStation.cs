using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GasStation : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/gas-station/

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

	public int CanCompleteCircuit(int[] gas, int[] cost)
	{
		//If the overall gas doesn't equal the overall cost, then we're guarenteed to fail
		if (gas.Sum() < cost.Sum())
		{
			return -1;
		}

		//If overall gas exceeds overall cost, we're guarenteed to succeed, why?
		//Basically because if we start at the correct place, just enough gas we'll have to reach 
		//back since anyway we have more gas than cost 
		int res = 0, total = 0;

		//If total dips below zero, we'll not start from there, we'll start at the next place.
		for (int i = 0; i < gas.Length; i++)
		{
			total += gas[i] - cost[i];
			if (total < 0)
			{
				total = 0;
				res = i + 1;
			}
		}
		return res;
	}

	#endregion

	#region Helper Methods	



	#endregion
}