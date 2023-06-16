
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MajorityElement : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/majority-element/description/

    #endregion

    #region Methods		

    public int MajorityElement_1(int[] nums)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dict.ContainsKey(nums[i]))
            {
                dict.Add(nums[i], 1);
            }
            else
            {
                dict[nums[i]] += 1;
            }
        }
        foreach (var entry in dict)
        {
            if (entry.Value >= (int)Math.Ceiling((decimal)nums.Length / 2))
            {
                return entry.Key;
            }
        }
        return 0;
    }

    public int MajorityElement_2(int[] nums)
    {
        Array.Sort(nums);
        return nums[(nums.Length - 1) / 2];
    }

    #endregion
}