using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FindPeakElement : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/find-peak-element/

    #endregion

    #region Method 1

    public int FindPeakElement_1(int[] nums)
    {
        int l = 0; int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            int movR = ToMoveR(m, nums);

            if (movR == 0)
            {
                return m;
            }
            else if (movR == -1)
            {
                r = m;
            }
            else
            { //movR == 1
                l = m + 1;
            }
        }
        //At this point L and R are same and by the given condition, peak will always exist
        return l;
    }

    //Comparing immediate adjacent values to findout which direction to move in
    private int ToMoveR(int m, int[] input)
    {
        //If on either ends, no need to compare the direction out of bounds
        if (m == 0)
        {
            return (input[m + 1] > input[m]) ? 1 : 0;
        }
        else if (m == input.Length - 1)
        {
            return (input[m - 1] > input[m]) ? -1 : 0;
        }

        //If in the middle, 
        if (input[m] < input[m - 1] || input[m] < input[m + 1])
        {
            //Either of the neighbors are greater => move right by default unless right is less
            return (input[m] < input[m + 1]) ? 1 : -1;
        }
        else //Both neighbors are less => we've found peak
            return 0;
    }

    #endregion

    #region Method 2

    public int FindPeakElement_2(int[] nums)
    {
        int l = 0; int r = nums.Length - 1; int peak = 0;
        Recurse(l, r, nums, ref peak);
        return peak;
    }

    private void Recurse(int l, int r, int[] nums, ref int peak)
    {
        if (l == r)
        {
            peak = l;
            return;
        }

        //Need to compare elements on the right only since m will never be 
        //on the right extreme edge unless l == r
        int m = l + (r - l) / 2;

        //Peak further to the right
        if (nums[m + 1] > nums[m])
        {
            l = m + 1;
        }
        //Peak further to the left
        else if (nums[m] > nums[m + 1])
        {
            r = m;
        }

        Recurse(l, r, nums, ref peak);
    }

    #endregion

    #region Method 3

    public int FindPeakElement_3(int[] nums)
    {
        int l = 0; int r = nums.Length - 1;

        while (l < r)
        {
            int m = l + (r - l) / 2;

            //Checking right element only
            if (nums[m + 1] > nums[m])
            {
                l = m + 1;
            }
            else if (nums[m + 1] < nums[m])
            {
                r = m;
            }
        }

        return l;
    }

    #endregion

}