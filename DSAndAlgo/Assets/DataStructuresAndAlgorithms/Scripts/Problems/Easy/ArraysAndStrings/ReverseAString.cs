using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReverseAString : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/reverse-string/

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

	public void ReverseString_Recursive(char[] s)
	{
		RecursiveReverse(s, (int)Math.Ceiling((float)(s.Length - 1) / 2));
	}

	public void ReverseString_Iterative(char[] s)
	{
		int l = (int)Math.Floor((float)(s.Length - 1) / 2);
		int r = (int)Math.Ceiling((float)(s.Length - 1) / 2);

		while (l >= 0 && r < s.Length)
		{
			Swap(s, l, r);
			l--; r++;
		}
	}

	public void ReverseString_Iterative_1(char[] s)
	{
		int m = (int)Math.Floor((decimal)s.Length / 2);
		for (int i = 0; i < s.Length; i++)
		{
			if (i >= m)
			{
				break;
			}

			Swap(s,i, (s.Length - 1) - i);
		}
	}

	#endregion

	#region Helper Methods	

	private void RecursiveReverse(char[] s, int i)
	{
		if (i == s.Length - 1)
		{
			goto swap;
		}

		RecursiveReverse(s, i + 1);

		swap:
		Swap(s, i, s.Length - 1 - i);
	}

	private void Swap(char[] s, int i, int j)
	{
		char I = s[i]; char J = s[j];
		s[i] = J; s[j] = I;
	}

	#endregion
}