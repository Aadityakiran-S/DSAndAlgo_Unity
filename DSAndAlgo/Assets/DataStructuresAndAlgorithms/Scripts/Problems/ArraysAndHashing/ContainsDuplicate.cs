using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ContainsDuplicate : MonoBehaviour
{
    #region Question

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
        Debug.Log("Does the array contain duplicates? " + CheckIfContainsDuplicate_1(_arrayToCheck));
    }

    #endregion

    #region Methods

    public bool CheckIfContainsDuplicate_1(int[] nums)
    {
        Hashtable entryTable = new Hashtable();

        for (int i = 0; i < nums.Length; i++)
        {
            if (entryTable.Contains(nums[i]))
            {
                return true;
            }

            entryTable.Add(nums[i], nums[i]);
        }

        return false;
    }

    public bool CheckIfContainsDuplicate_2(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}