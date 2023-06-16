using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SummaryRanges : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/summary-ranges/description/

    #endregion

    #region Methods		

    public IList<string> SummaryRanges_1(int[] nums)
    {
        IList<string> output = new List<string>();

        //Edge cases
        if (nums == null || nums.Length == 0)
        {
            return output;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int start = nums[i];
            //Skipping over all but last element in range (that's why we're checking with i + 1)
            while (i + 1 < nums.Length && nums[i + 1] - nums[i] == 1)
            {
                i++;
            }
            //Single element in range
            if (start == nums[i])
            {
                output.Add($"{start}");
            }
            else
            {
                output.Add($"{start}->{nums[i]}");
            }
        }

        return output;
    }

    public IList<string> SummaryRanges_2(int[] nums)
    {
        IList<string> output = new List<string>();

        //Edge cases
        if (nums == null || nums.Length == 0)
        {
            return output;
        }

        int start = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (i < nums.Length - 1 && nums[i + 1] - nums[i] == 1)
            {
                continue;
            }

            //Single element in range
            if (start == nums[i])
            {
                output.Add($"{start}");
            }
            //More than one element in range
            else
            {
                output.Add($"{start}->{nums[i]}");
            }

            //Setting new start. In case of last element, just won't enter first if, rest will happen
            if (i < nums.Length - 1)
            {
                start = nums[i + 1];
            }
        }

        return output;
    }

    #endregion
}