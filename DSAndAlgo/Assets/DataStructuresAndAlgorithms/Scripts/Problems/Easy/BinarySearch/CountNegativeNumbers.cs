using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CountNegativeNumbers : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/

    #endregion

    #region Methods		

    public int CountNegatives_1(int[][] grid)
    {
        int negativeCount = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            int l = 0; int r = grid[i].Length - 1;
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (grid[i][m] < 0)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            if (grid[i][l] < 0)
            {
                negativeCount += (grid[i].Length - l);
            }
        }

        return negativeCount;
    }

    public int CountNegatives(int[][] grid)
    {
        int count = 0; int currentRowNegativeIndex = grid[0].Length - 1;
        foreach (int[] row in grid)
        {
            //Since columns are also sorted, CRNI for a row will never decrease
            //as we go down. So, we accumulate the entries on the way
            while (currentRowNegativeIndex >= 0 && row[currentRowNegativeIndex] < 0)
            {
                currentRowNegativeIndex--;
            }
            //Accumulating count at the end of each row
            count += (row.Length - (currentRowNegativeIndex + 1));
        }
        return count;
    }

    #endregion
}