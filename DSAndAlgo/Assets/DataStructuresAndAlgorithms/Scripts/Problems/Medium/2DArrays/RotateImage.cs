using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RotateImage : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/rotate-image/description/

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

	#region Extra Space Implementation

	public void Rotate_ExtraSpace(int[][] input)
	{
		int n = input.Length;
		int[][] output = new int[n][];

		for (int i = 0; i < n; i++)
		{
			output[i] = new int[n];
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				output[i][j] = input[(n - 1) - j][i];
			}
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				input[i][j] = output[i][j];
			}
		}
	}

	#endregion

	#region Constant Space (In place) implementation

	public void Rotate_NoExtraSpace(int[][] input)
	{
		int n = input.Length; //Caching length since we need it all the timer

		//Take transpose (swap everything except for main diagonal)
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (i > j)
				{
					SwapIn2DArray(i, j, input);
				}
			}
		}

		//Reverse each row in input to get output
		for (int i = 0; i < n; i++)
		{
			Reverse(i, input);
		}
	}

	//Simply swaps 2 elements in 2D matrix
	private void SwapIn2DArray(int i, int j, int[][] input)
	{
		int one = input[i][j]; int two = input[j][i];
		input[i][j] = two; input[j][i] = one;
	}

	//Reverse in place algorithm (again since we have to do it in place)
	private void Reverse(int i, int[][] input)
	{
		int[] arr = input[i]; int m = (int)Math.Floor((double)arr.Length / 2);
		for (int j = 0; j < arr.Length; j++)
		{
			if (j >= m)
			{
				break;
			}
			Swap(j, (arr.Length - 1) - j, arr);
		}
	}

	//Swap element it 1D array (Helper function)
	private void Swap(int i, int j, int[] arr)
	{
		int I = arr[i]; int J = arr[j];
		arr[i] = J; arr[j] = I;
	}

	#endregion
}