using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FindDuplicateNumber : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/find-the-duplicate-number/description/

    #endregion

    #region Methods		

    public int FindDuplicate_1(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Contains(nums[i]))
            {
                set.Add(nums[i]);
            }
            else
            {
                return nums[i];
            }
        }
        return 0;
    }

    public int FindDuplicate_2(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int idx = Math.Abs(nums[i]);
            if (nums[idx] < 0)
            {
                return idx;
            }
            nums[idx] = -nums[idx];
        }
        return 0;
    }

    public int FindDuplicate_3(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return nums[i];
            }
        }
        return 0;
    }

    public int FindDuplicate_FloydAlgo(int[] nums)
    {
        //Using Floyd's algo to find meeting point
        int slow = 0, fast = 0;
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        //At this point, slow and fast have met
        int first = 0;
        while (first != slow)
        {
            slow = nums[slow];
            first = nums[first];
        }

        return first;
    }

    #endregion
}