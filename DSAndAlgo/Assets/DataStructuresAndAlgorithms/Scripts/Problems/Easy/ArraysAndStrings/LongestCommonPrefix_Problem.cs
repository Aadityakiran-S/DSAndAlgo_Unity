using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LongestCommonPrefix_Problem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/longest-common-prefix/description/

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

	public string LongestCommonPrefix(string[] input)
	{
		if (input.Length == 0)
		{
			return "";
		}

		string output = input[0];
		for (int i = 1; i < input.Length; i++)
		{
			if (output.Length == 0)
			{
				return ""; //No common prefix
			}

			//Iterate over the min between output and next string
			int min = Math.Min(output.Length, input[i].Length);
			for (int j = 0; j < min; j++)
			{
				if (output[j] != input[i][j])
				{
					output = output.Substring(0, j);
					break;
				}
			}
			//Cut output off if next string is smaller than output
			output = output.Substring(0, Math.Min(output.Length, min));
		}

		return output;
	}

	#endregion
}