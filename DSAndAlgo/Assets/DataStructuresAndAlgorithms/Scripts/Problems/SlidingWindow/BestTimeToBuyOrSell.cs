using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BestTimeToBuyOrSell : MonoBehaviour
{
    #region Question
    //You are given an array prices where prices[i] is the price of a given stock on the ith day.
    //You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future
    //to sell that stock.
    //Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.

    //Example 1:

    //Input: prices = [7, 1, 5, 3, 6, 4]
    //Output: 5
    //Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    //Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
    //Example 2:

    //Input: prices = [7,6,4,3,1]
    //	Output: 0
    //Explanation: In this case, no transactions are done and the max profit = 0.

    //Constraints:

    //1 <= prices.length <= 105
    //0 <= prices[i] <= 104
    #endregion

    #region References

    [SerializeField] int[] _prices;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        Debug.Log("Max profit given prices is: " + MaxProfit_Optimized(_prices));
    }

    #endregion

    #region Methods

    public int MaxProfit_BruteForce(int[] prices) //O(n^2)
    {
        if (prices.Length == 0)
        {
            Debug.Log("You haven't entered anything man");
            return 0;
        }

        int currentMaxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] - prices[i] > currentMaxProfit)
                {
                    currentMaxProfit = prices[j] - prices[i];
                }
            }
        }

        return currentMaxProfit;
    }

    public int MaxProfit_Optimized(int[] prices)
    {
        int maxProfit = 0; int l = 0; int r = 1;

        for (int i = 0; i < prices.Length - 1; i++)
        {
            if (prices[r] - prices[l] > maxProfit)
            {
                maxProfit = prices[r] - prices[l];
            }

            if (prices[r] < prices[l])
            {
                l = r;
            }

            r += 1;
        }

        return maxProfit;
    }

    #endregion
}