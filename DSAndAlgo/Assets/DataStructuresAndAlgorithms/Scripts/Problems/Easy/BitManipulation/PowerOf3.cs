using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PowerOf3 : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/power-of-three/description/

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

	public bool IsPowerOfThree(int n)
	{
		if (n <= 0)
		{
			return false;
		}
		if (n == 1)
		{
			return true;
		}

		while (n != 3)
		{
			if (n % 3 != 0)
			{
				return false;
			}
			n = n / 3;
		}

		return true;
	}

	#endregion

	#region Helper Methods	



	#endregion
}