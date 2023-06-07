using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SingleElementInSortedArray : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/single-element-in-a-sorted-array/description/

    #endregion

    #region Methods		

    //All odd indices will have it's duplicate on the left and even indices on the 
    //right UNLESS the duplicate has come in between somewhere
    public int SingleNonDuplicate_1(int[] nums)
    {
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            //Duplicate hasn't arrived until mid
            if ((m % 2 == 0 && nums[m] == nums[m + 1]) ||
                (m % 2 == 1 && nums[m] == nums[m - 1]))
            {
                l = m + 1; //Search after mid
            }
            //Duplicate arrived before mid
            else
            {
                r = m; //Search before mid
            }
        }
        return nums[l]; //Duplicate will be at left
    }

    //All odd indices will have it's duplicate on the left and even indices on the 
    //right UNLESS the duplicate has come in between somewhere
    public int SingleNonDuplicate_2(int[] nums)
    {
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            //Making mid even if it turns out to be odd
            //for easy if statement writing
            if (m % 2 == 1)
            {
                m--;
            }
            if (nums[m] != nums[m + 1])
            {
                r = m;
            }
            else
            {
                l = m + 2;
            }
        }
        return nums[l]; //Duplicate will be at left
    }

    #endregion
}