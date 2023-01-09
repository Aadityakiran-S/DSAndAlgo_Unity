using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ThreeSumProblem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/3sum/

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

	public IList<IList<int>> ThreeSum(int[] nums)
	{
        IList<IList<int>> output = new List<IList<int>>();

        if (nums == null || nums.Length < 3)
            return output;

        Array.Sort(nums);

        //Iterating to second last element
        for (int i = 0; i < nums.Length - 2; i++)
        {
            //Cannot form a triplet adding to zero if least element itself is positive
            //To find unique element, need to start from an unseen before element
            if (nums[i] > 0 || i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            //After this point it's basically 2Sum 2 (when input array is sorted)
            int target = -nums[i];
            int j = i + 1; int k = nums.Length - 1;

            while (j < k)
            {
                //If equal, add to output and update left and right
                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    List<int> temp = new List<int>() { nums[i], nums[j], nums[k] };
                    output.Add(temp);

                    j++; k--;
                }
                //If sum falls short, increment left
                else if (nums[i] + nums[j] + nums[k] < 0)
                    j++;
                else //If sum exceeds, decrement right
                    k--;
            }
        }

        return output;
    }

	#endregion
}