using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SubSets_1 : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/subsets/

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

    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> results = new List<IList<int>>();
        List<int> subset = new List<int>();

        GenerateSubset_Recursive(nums, 0, subset, results);

        return results;
    }

    #endregion

    #region Helper Functions

    private void GenerateSubset_Recursive(int[] nums, int i, IList<int> subset, IList<IList<int>> res)
    {
        //Base case:=> When we've accounted for deciding for all elements 
        if (i >= nums.Length)
        {
            IList<int> subsetClone = new List<int>(subset);
            res.Add(subsetClone);
            return;
        }

        //Adding the current element to results
        subset.Add(nums[i]);
        GenerateSubset_Recursive(nums, i + 1, subset, res);

        //Adding nothing 
        subset.RemoveAt(subset.Count - 1);
        GenerateSubset_Recursive(nums, i + 1, subset, res);
    }

    #endregion
}