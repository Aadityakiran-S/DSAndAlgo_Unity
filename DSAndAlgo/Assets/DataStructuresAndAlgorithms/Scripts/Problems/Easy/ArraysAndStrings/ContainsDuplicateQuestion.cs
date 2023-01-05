using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ContainsDuplicateQuestion : MonoBehaviour
{
    #region Question
    //https://leetcode.com/problems/contains-duplicate/

    //Given an integer array nums, return
    //true if any value appears at least twice in the array,
    //and return false if every element is distinct.

    //Example 1:

    //Input: nums = [1,2,3,1]
    //    Output: true
    //Example 2:

    //Input: nums = [1,2,3,4]
    //    Output: false
    //Example 3:

    //Input: nums = [1,1,1,3,3,4,3,2,4,2]
    //    Output: true

    #endregion

    #region References

    [SerializeField] int[] _arrayToCheck;

    #endregion

    #region UnityLifecycle

    private void Start()
    {

    }

    #endregion

    #region Methods

    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> entryDict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int val = nums[i];

            if (entryDict.ContainsKey(val))
            {
                return true;
            }
            else
            {
                entryDict.Add(val, val);
            }
        }

        return false;
    }

    #endregion
}