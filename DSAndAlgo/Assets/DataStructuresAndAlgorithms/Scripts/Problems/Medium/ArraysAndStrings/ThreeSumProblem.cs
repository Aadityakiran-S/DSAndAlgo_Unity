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
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums); //Need to sort input for 2Sum II to be applied in inner loop

        //Setting the first pointer
        for (int i = 0; i <= nums.Length - 3; i++)
        {

            //Skipping over duplicates in the first element of triplet
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            //Setting pointers inside to do 2 Sum II
            int j = i + 1; int k = nums.Length - 1; int target = -nums[i];
            while (j < k)
            {
                if (nums[j] + nums[k] > target)
                {
                    k--;
                }
                else if (nums[j] + nums[k] < target)
                {
                    j++;
                }
                //We've found our triplet
                else
                {
                    result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                    j++;

                    //Skipping over duplicates in the inner loop as well
                    while (nums[j] == nums[j - 1] && j < k)
                    {
                        j++;
                    }
                }
            }
        }

        return result;
    }

    #endregion
}