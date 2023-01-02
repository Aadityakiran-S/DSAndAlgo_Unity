using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CostOfClimbingStairs : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/min-cost-climbing-stairs/

    //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.
    //Once you pay the cost, you can either climb one or two steps.
    //You can either start from the step with index 0, or the step with index 1.
    //Return the minimum cost to reach the top of the floor.

    //Example 1:
    //Input: cost = [10, 15, 20]
    //Output: 15

    //Explanation: You will start at index 1.
    //- Pay 15 and climb two steps to reach the top.
    //The total cost is 15.


    //Example 2:
    //Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
    //Output: 6

    //Explanation: You will start at index 0.
    //- Pay 1 and climb two steps to reach index 2.
    //- Pay 1 and climb two steps to reach index 4.
    //- Pay 1 and climb two steps to reach index 6.
    //- Pay 1 and climb one step to reach index 7.
    //- Pay 1 and climb two steps to reach index 9.
    //- Pay 1 and climb one step to reach the top.
    //The total cost is 6.


    //Constraints:

    //2 <= cost.length <= 1000
    //0 <= cost[i] <= 999

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

    public int MinCostClimbingStairs_Iterative(int[] cost)
    {
        //Min length of costs is 2 (given in constraints)
        if (cost.Length == 2)
        {
            return Math.Min(cost[0], cost[1]);
        }

        int[] values = new int[cost.Length];
        int dp1 = cost[0];
        int dp2 = cost[1];

        for (int i = 2; i < values.Length; i++)
        {
            int currentValue = cost[i] + Math.Min(dp2, dp1);
            dp1 = dp2;
            dp2 = currentValue;
        }

        return Math.Min(dp1, dp2);
    }

    public int MinCostClimbingStairs_Recursive(int[] cost)
    {
        int[] valuesArray = new int[cost.Length];
        for (int i = 0; i < valuesArray.Length; i++)
        {
            valuesArray[i] = int.MinValue;
        }

        return Math.Min(MinCost_Array(cost.Length - 1, cost, valuesArray),
            MinCost_Array(cost.Length - 2, cost, valuesArray));
    }

    private int MinCost_Array(int step, int[] cost, int[] values)
    {
        //We've already stored the min cost of the step we're at
        if (values[step] != int.MinValue)
        {
            return values[step];
        }

        //Base case is when we're either at 0th, 1rst or negative step
        if (step < 0)
        {
            return 0;
        }
        else if (step == 1 || step == 0)
        {
            return cost[step];
        }

        values[step] = cost[step] + Math.Min(MinCost_Array(step - 1, cost, values),
            MinCost_Array(step - 2, cost, values));

        return values[step];
    }

    private int MinCost_HashMap(int step, int[] cost, Dictionary<int, int> valuesDict)
    {
        //Memoizing calculated values to facilitate for reduction in steps
        if (valuesDict.ContainsKey(step))
        {
            return valuesDict[step];
        }

        //Base case is when we're either at 0th, 1rst or negative step
        if (step < 0)
        {
            return 0;
        }
        else if (step == 1 || step == 0)
        {
            return cost[step];
        }

        //To prevent index out of bounds error on the last step
        int currentCost;
        if (step == cost.Length)
            currentCost = 0;
        else
            currentCost = cost[step];

        valuesDict.Add(step, currentCost + Math.Min(MinCost_HashMap(step - 1, cost, valuesDict),
            MinCost_HashMap(step - 2, cost, valuesDict)));

        return valuesDict[step];
    }

    #endregion
}