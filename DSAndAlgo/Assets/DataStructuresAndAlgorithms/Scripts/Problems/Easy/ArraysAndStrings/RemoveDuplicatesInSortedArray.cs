using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RemoveDuplicatesInSortedArray : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/delete-node-in-a-linked-list/description/

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
	
	public int RemoveDuplicates(int[] nums)
	{
		int u = 0; //pointer to keep track of index of unique
		for (int i = 0; i < nums.Length; i++)
		{
			if (i == 0)
			{
				//Do nothing: Coz anyway the first element will be the
				//first unique
			}
			//Next unique element spotted
			else if (nums[i] != nums[i - 1])
			{
				//Increment unique pointer and replace 
				//Whatever is there with curr element
				u++; nums[u] = nums[i];
			}
		}

		return u + 1; //Return index of unique + 1 to get count
	}


	#endregion

	#region Helper Methods	



	#endregion
}