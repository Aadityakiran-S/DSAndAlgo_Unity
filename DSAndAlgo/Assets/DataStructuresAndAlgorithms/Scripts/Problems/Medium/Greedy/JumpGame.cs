using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class JumpGame : MonoBehaviour
{
	#region Question
	
	

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

	public bool CanJump(int[] nums)
	{
		//Setting pointer at the end and checking if it's possible to reach
		//it with each iteration backwards
		int goal = nums.Length - 1;
		for (int i = nums.Length - 1; i >= 0; i--)
		{
			if (i + nums[i] >= goal)
			{
				goal = i;
			}
		}

		//If at the end we'll be able to reach the start, input is valid
		return goal == 0;
	}


	#endregion

	#region Helper Methods	



	#endregion
}