using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TrappingRainwater : MonoBehaviour
{
    #region Question
    //Link: https://leetcode.com/problems/trapping-rain-water/

    //Given n non-negative integers representing an elevation map where the width of each bar is 1,
    //compute how much water it can trap after raining.

    //Example 1:

    //Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
    //Output: 6
    //Explanation: The above elevation map(black section) is represented by array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1].
    //In this case, 6 units of rain water (blue section) are being trapped.

    //Example 2:

    //Input: height = [4,2,0,3,2,5]
    //Output: 9


    //Constraints:

    //n == height.length
    //1 <= n <= 2 * 104
    //0 <= height[i] <= 105

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

    #region Methods	

    //Two pointer solution. Pretty simple actually mechanism is same just traversal is different
    private int Trap_Optimized(int[] heights)//T:n, S:1
    {
        //Error check
        if (heights.Length == 0 || heights.Length == 1)
        {
            return 0;
        }

        //Setting variables
        int totalAreaOfWater = 0;
        int left = 0; int right = heights.Length - 1;
        int maxLeft = heights[left]; int maxRight = heights[right];

        //Two pointer method so exit condition is when pointers cross
        while(left < right)
        {
            int currentWater;

            //Min of the max from either left or right is used to calculate water above current
            if (maxLeft <= maxRight)
            {
                currentWater = maxLeft - heights[left];
                left++; maxLeft = Math.Max(maxLeft, heights[left]);
            }
            else
            {
                currentWater = maxRight - heights[right];
                right--; maxRight = Math.Max(maxRight, heights[right]);
            }

            totalAreaOfWater += currentWater;
        }

        return totalAreaOfWater;
    }

    private int Trap_BruteForce(int[] height) //T:n^2 S:1
    {
        //Error check
        if(height.Length == 0 || height.Length == 1)
        {
            return 0;
        }

        int totalAreaOfWater = 0;

        //Iterating through all and simply finding how much water is above each block
        for (int i = 0; i < height.Length; i++)
        {
            //The water will be trapped by the smallest of the largest blocks before and after the current
            //Minus the height of the current block
            int area = Math.Min(MaxLeft(i, height), MaxRight(i, height)) - height[i];

            //In case the result is negative => water cannot fit above so ignore o/w add to total
            if (area > 0) totalAreaOfWater += area;
        }

        return totalAreaOfWater;
    }

    #endregion

    #region Helper functions

    //Traverse from current point and find out largest wall before 
    int MaxLeft(int i, int[] height)
    {
        int maxLeft = 0;

        for (int j = i; j >= 0; j--)
        {
            maxLeft = Math.Max(height[j], maxLeft);
        }

        return maxLeft;
    }

    //Traverse from current point and find out largest wall after
    int MaxRight(int i, int[] height)
    {
        int maxRight = 0;

        for (int j = i; j < height.Length; j++)
        {
            maxRight = Math.Max(height[j], maxRight);
        }

        return maxRight;
    }

    #endregion
}