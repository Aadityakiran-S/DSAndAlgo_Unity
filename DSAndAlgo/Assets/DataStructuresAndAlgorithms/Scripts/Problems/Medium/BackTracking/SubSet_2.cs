using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SubSet_2 : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/subsets-ii/

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

    #region Public methods
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        IList<IList<int>> results = new List<IList<int>>();
        List<int> subset = new List<int>();

        Array.Sort(nums);//Array needs to be sorted for us to skip duplicates

        FindSubsWithDup_Rec(nums, 0, subset, results);

        return results;
    }
    #endregion

    #region Private Methods
    private void FindSubsWithDup_Rec(int[] nums, int i, List<int> subset, IList<IList<int>> res)
    {
        //Base Case: When we're at the end of adding the elements in nums
        if (i >= nums.Length)
        {
            List<int> clone = new List<int>(subset);
            res.Add(clone);
            return;
        }

        //Add entry
        subset.Add(nums[i]);
        FindSubsWithDup_Rec(nums, i, subset, res);

        //Skipping to front of duplicates if exists
        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) 
            i++;

        //Adding nothing
        subset.RemoveAt(subset.Count - 1); //Removing the last entry since we're adding nothing
        FindSubsWithDup_Rec(nums, i, subset, res);
    }
    #endregion
}