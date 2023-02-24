using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class JumpGameII : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/jump-game-ii/description/

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

	public int Jump(int[] nums)
	{
		//Initilizing pointers to start at 0 and max possible 
		//jump from zero
		int result = 0;
		int left = 0; int right = 0;

		//Jumping in sets. Check each set for max jump and
		//set pointers accordingly
		while (right < nums.Length - 1)
		{
			int farthest = 0;

			//At each point in the set, checking how far you can jump.
			for (int i = left; i <= right; i++)
			{
				//caching max possible distance
				farthest = Math.Max(farthest, i + nums[i]);
			}

			//Setting the boundaries of the new set using farthest value
			left = right + 1;
			right = farthest;
			result++; //for each set, adding jump value.
		}

		return result;
	}

	#endregion

	#region Helper Methods	



	#endregion
}