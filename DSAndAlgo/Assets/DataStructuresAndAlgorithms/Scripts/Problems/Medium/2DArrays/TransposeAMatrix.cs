using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TransposeAMatrix : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/transpose-matrix/description/

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

	public int[][] Transpose(int[][] input)
	{
		int[][] output = new int[input[0].Length][];
		for (int i = 0; i < output.Length; i++)
		{
			output[i] = new int[input.Length];
		}

		for (int i = 0; i < input.Length; i++)
		{
			for (int j = 0; j < input[0].Length; j++)
			{
				output[j][i] = input[i][j];
			}
		}

		return output;
	}

	#endregion
}