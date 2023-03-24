using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DailyTemperaturesProblem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/daily-temperatures/

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

	public int[] DailyTemperatures(int[] input)
	{
		Stack<int[]> stk = new Stack<int[]>(); int[] res = new int[input.Length];

		for (int i = 0; i < input.Length; i++)
		{
			while (stk.Count > 0 && input[i] > stk.Peek()[0])
			{
				int[] entry = stk.Pop();
				res[entry[1]] = i - entry[1];
			}

			stk.Push(new int[] { input[i], i });
		}

		return res;
	}


	#endregion

	#region Helper Methods	



	#endregion
}