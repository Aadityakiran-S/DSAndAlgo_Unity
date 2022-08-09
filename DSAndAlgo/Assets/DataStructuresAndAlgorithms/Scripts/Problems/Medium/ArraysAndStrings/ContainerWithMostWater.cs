using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ContainerWithMostWater : MonoBehaviour
{
	#region Question
	//You are given an integer array height of length n.
	//There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and(i, height[i]).
	//Find two lines that together with the x-axis form a container, such that the container contains the most water.
	//Return the maximum amount of water a container can store.
	//Notice that you may not slant the container.

	//Example 1:
	//Input: height = [1,8,6,2,5,4,8,3,7]
	//Output: 49
	//Explanation: The above vertical lines are represented by array[1, 8, 6, 2, 5, 4, 8, 3, 7].
	//In this case, the max area of water (blue section) the container can contain is 49.

	//Example 2:
	//	   Input: height = [1, 1]
	//	   Output: 1

	//	   Constraints:
	//n == height.length
	//2 <= n <= 105
	//0 <= height[i] <= 104
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

	public int MaxArea_BruteForce(int[] heights) //T: n^2, S: 1
	{
		int currentMaxArea = 0;

        for (int i = 0; i < heights.Length - 1; i++) // i: 0 -> h[second last element]
        {
            for (int j = i + 1; j < heights.Length; j++) // j: i -> h[last element]
            {
				int currentArea = Math.Min(heights[i], heights[j]) * Math.Abs(j - i);
				currentMaxArea = Math.Max(currentMaxArea, currentArea);
			}
        }

		return currentMaxArea;
	}

	public int MaxArea_Optimized(int[] heights) //S: 1, T: n
    {
		int currentMaxArea = 0; int i = 0; int j = heights.Length - 1;

		while(i < j)
        {
			int currentArea = Math.Min(heights[i], heights[j]) * Math.Abs(j - i);
			currentMaxArea = Math.Max(currentMaxArea, currentArea);

			if (heights[i] <= heights[j]) //Shifting the min pointer closer to the other
			{
				i++;
			}
			else
				j--;
		}

		return currentMaxArea;
	}

	#endregion
}