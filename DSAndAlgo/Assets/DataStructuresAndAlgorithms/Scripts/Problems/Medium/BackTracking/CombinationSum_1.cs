using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CombinationSum_1 : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/combination-sum/description/

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

    #region Public Functions
    public IList<IList<int>> CombinationSum(int[] input, int target)
    {
        IList<IList<int>> results = new List<IList<int>>();
        Array.Sort(input); //Need to sort the inputs to eliminate duplicate entries

        CombinationSum_Recurse(input, target, 0, new List<int>(), results);

        return results;
    }
    #endregion

    #region Private Functions
    private void CombinationSum_Recurse(int[] nums, int target, int i, List<int> subset,
    IList<IList<int>> res)
    {
        //Base case: Comparison on sum
        int sum = 0;
        foreach (int entry in subset)
        {
            sum += entry;
        }
        //(1): If sum of elements reaches target exactly => Put subset in results and exit
        if (target == sum)
        {
            List<int> clone = new List<int>(subset);
            res.Add(clone);
            return;
        }
        //(2): If sum exceeds target => Just exit, we can't proceed further
        else if (target < sum)
        {
            return;
        }

        //Iterate and choose without duplicate
        for (int j = i; j < nums.Length; j++)
        {
            subset.Add(nums[j]);
            CombinationSum_Recurse(nums, target, j, subset, res);
            subset.RemoveAt(subset.Count - 1);
        }
    }
    #endregion
}