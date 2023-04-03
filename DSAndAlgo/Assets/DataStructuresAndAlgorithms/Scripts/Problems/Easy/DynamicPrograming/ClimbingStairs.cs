using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ClimbingStairs : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/climbing-stairs/

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

	public int ClimbStairs_DP(int n)
	{
		int one = 1; int two = 1;

		//DP solution: Basically 
		//start from the end and check how many ways you can reach end
		//one way to reach end from end itself, one way from just before end...
		//the other way you'll go out of bounds, then repeat the process for 
		//rest since you'll have cached the values for the rest 
		int currNum = n - 2;
		while (currNum >= 0)
		{
			int zero = one + two;
			two = one; one = zero;
			currNum--;
		}
		return one;
	}

	public int ClimbStairs_Recursive(int n)
	{
		Dictionary<int, int> dict = new Dictionary<int, int>();
		return ClimbStairs_Recursive_Internal(0, n, dict);
	}

	private int ClimbStairs_Recursive_Internal(int i, int n, Dictionary<int, int> dict)
	{
		//Memoization
		if (dict.ContainsKey(i))
		{
			return dict[i];
		}
		//Invalid path due to overshoot
		else if (i > n)
		{
			return 0;
		}
		//Valid path.
		else if (i == n)
		{
			return 1;
		}

		int output = ClimbStairs_Recursive_Internal(i + 1, n, dict)
			+ ClimbStairs_Recursive_Internal(i + 2, n, dict);

		dict.Add(i, output);

		return output;
	}

	#endregion

	#region Helper Methods	



	#endregion
}