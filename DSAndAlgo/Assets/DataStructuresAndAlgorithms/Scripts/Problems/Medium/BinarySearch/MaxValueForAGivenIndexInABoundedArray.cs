using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MaxValueForAGivenIndexInABoundedArray : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/maximum-value-at-a-given-index-in-a-bounded-array/

    #endregion

    #region Methods		

    public int MaxValue(int n, int index, int maxSum)
    {
        //Performing Binary Search
        int l = 1; int r = maxSum;
        while (l < r)
        {
            //Finding middle using m = l + (r - l)/2 will result in infinite loop
            int m = (l + r + 1) / 2;

            //If optimal sum is obtained, can exit out of loop immediately
            decimal currSum = GetSum(index, m, n);
            if (currSum == maxSum)
            {
                return m;
            }

            //Narrowing search range down to where the sum equals the maxSum
            if (currSum <= maxSum)
            {
                l = m;
            }
            else
            {
                r = m - 1;
            }
        }

        return l; //Last remaining element will have max sum
    }

    //Outputting to decimal to prevent rounding errors while operating on large values
    private decimal GetSum(int index, int value, int n)
    {
        decimal count = 0;

        // On index's left:
        // If value > index, there are index + 1 numbers in the arithmetic sequence:
        // [value - index, ..., value - 1, value].
        // Otherwise, there are value numbers in the arithmetic sequence:
        // [1, 2, ..., value - 1, value], plus a sequence of length (index - value + 1) of 1s. 
        if (value > index)
        {
            count += (decimal)(value + value - index) * (index + 1) / 2;
        }
        else
        {
            count += (decimal)(value + 1) * value / 2 + index - value + 1;
        };
        // On index's right:
        // If value >= n - index, there are n - index numbers in the arithmetic sequence:
        // [value, value - 1, ..., value - n + 1 + index].
        // Otherwise, there are value numbers in the arithmetic sequence:
        // [value, value - 1, ..., 1], plus a sequence of length (n - index - value) of 1s. 
        if (value >= n - index)
        {
            count += (decimal)(value + value - n + 1 + index) * (n - index) / 2;
        }
        else
        {
            count += (decimal)(value + 1) * value / 2 + n - index - value;
        }

        return count - value; //Counted value twice, so have to decrease it here
    }

    #endregion
}