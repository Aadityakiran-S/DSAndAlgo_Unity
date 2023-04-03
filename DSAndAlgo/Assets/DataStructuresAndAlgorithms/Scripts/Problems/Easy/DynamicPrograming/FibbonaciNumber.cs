using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FibbonaciNumber : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/fibonacci-number/submissions/

	#endregion

	#region References

	private Dictionary<int, int> _dict;

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

	public int Fib_Iterative(int n)
	{
		List<int> output = new List<int> { 0, 1 };
		for (int i = 2; i <= n; i++)
		{
			output.Add(output[i - 1] + output[i - 2]);
		}

		return output[n];
	}

	public int Fib_Recursive(int n)
	{
		_dict = new Dictionary<int, int>();

		return Fib_R(n);
	}

	#endregion

	#region Helper Methods	

	private int Fib_R(int n)
	{
		if (_dict.ContainsKey(n))
		{
			return _dict[n];
		}
		else if (n == 1)
		{
			return 1;
		}
		else if (n < 1)
		{
			return 0;
		}

		int output = Fib_R(n - 1) + Fib_R(n - 2);
		_dict.Add(n, output);

		return output;
	}

	#endregion
}