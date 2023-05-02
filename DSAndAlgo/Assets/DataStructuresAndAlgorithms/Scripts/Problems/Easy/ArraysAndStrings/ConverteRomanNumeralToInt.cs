using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ConverteRomanNumeralToInt : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/roman-to-integer/description/

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
	public int RomanToInt_IterateInReverse(string s)
	{
		int output = 0;
		//Iterating in reverse
		for (int i = s.Length - 1; i >= 0; i--)
		{
			if (i == s.Length - 1)
			{
				output += Helper(s[i]);
			}
			else
			{
				//If prev > curr => add to total
				if (Helper(s[i]) >= Helper(s[i + 1]))
				{
					output += Helper(s[i]);
				}
				//If prev < curr => subtract from total
				else
				{
					output -= Helper(s[i]);
				}
			}
		}

		return output;
	}

	public int RomanToInt_IterateForward(string s)
	{
		int output = 0; Stack<char> stack = new Stack<char>();
		//Comparing every two elements against eachother
		for (int i = 0; i < s.Length; i++)
		{
			//Only for first element
			if (stack.Count == 0)
			{
				output += Helper(s[i]);
			}
			//From second element onward
			else
			{
				//If prev is > curr => we simply add
				if (Helper(stack.Peek()) >= Helper(s[i]))
				{
					output += Helper(s[i]);
				}
				//If prev < curr => We need to sub prev from overall sum
				//and add curr - prev to our output
				else
				{
					output += Helper(s[i]) - 2 * (Helper(stack.Peek()));
				}
				stack.Pop();
			}
			stack.Push(s[i]);
		}

		return output;
	}


	#endregion

	#region Helper Methods	

	private int Helper(char c)
	{
		int output = 0;
		switch (c)
		{
			case 'I':
				output = 1;
				break;
			case 'V':
				output = 5;
				break;
			case 'X':
				output = 10;
				break;
			case 'L':
				output = 50;
				break;
			case 'C':
				output = 100;
				break;
			case 'D':
				output = 500;
				break;
			case 'M':
				output = 1000;
				break;
			default:
				output = 0;
				break;
		}

		return output;
	}

	#endregion
}