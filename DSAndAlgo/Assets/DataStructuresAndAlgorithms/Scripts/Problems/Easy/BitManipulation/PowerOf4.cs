using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PowerOf4 : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/power-of-four/

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

	#region Top Down Approach

	public bool IsPowerOfFour_TopDown(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		else if (n == 1)
		{
			return true;
		}

		while (n != 4)
		{
			if (n % 4 != 0)
			{
				return false;
			}
			n = n / 4;
		}

		return (n == 4);
	}

	#endregion

	#region Logarithm solutions

	public bool IsPowerOfFour_Log1(int n)
	{
		if (n <= 0)
		{
			return false;
		}

		decimal output = (decimal)Math.Log(n, 4);

		return Math.Floor(output) == Math.Ceiling(output);
	}

	public bool IsPowerOfFour_Log2(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		decimal log = (decimal)Math.Log(n, 4);
		return log % 1 == 0;
	}

	#endregion

	#region Exponent Equation
	public bool IsPowerOfFour_Exponent(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		decimal log = (decimal)Math.Log(n, 4);
		return log % 1 == 0;
	}
	#endregion

	#region Recursive

	public bool IsPowerOfFour_Recursive(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		if (n == 1)
		{
			return true;
		}
		if (n % 4 != 0)
		{
			return false;
		}

		n = n / 4;
		return IsPowerOfFour_Recursive(n);
	}

	#endregion

	#region Bit manipulation

	public bool IsPowerOfFour_BitManipulation(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		else if (n == 1)
		{
			return true;
		}

		int oneCount = 0; int bitCount = 0;
		while (n != 0)
		{
			if ((n & 1) == 1)
			{
				oneCount++;
			}
			bitCount++;
			n = n >> 1;
		}

		return oneCount == 1 && (bitCount % 2 != 0);
	}

	#endregion
}