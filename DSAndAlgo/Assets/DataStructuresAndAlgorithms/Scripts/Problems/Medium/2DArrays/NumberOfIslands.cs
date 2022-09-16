using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NumberOfIslands : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/number-of-islands/

    //Given an m x n 2D binary grid grid which represents a map of '1's(land) and '0's(water), return the number of islands.
    //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
    //You may assume all four edges of the grid are all surrounded by water.

    //Example 1:

    //Input: grid = [
    //  ["1", "1", "1", "1", "0"],
    //  ["1","1","0","1","0"],
    //  ["1","1","0","0","0"],
    //  ["0","0","0","0","0"]
    //]

    //Output: 1

    //Example 2:

    //Input: grid = [
    //  ["1","1","0","0","0"],
    //  ["1","1","0","0","0"],
    //  ["0","0","1","0","0"],
    //  ["0","0","0","1","1"]
    //]

    //Output: 3


    //Constraints:

    //m == grid.length
    //n == grid[i].length
    //1 <= m, n <= 300
    //grid[i][j] is '0' or '1'.
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

    private int NumIslands(char[][] grid)
    {
        int count = 0;

        //Sequentially going through array elements
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                if (grid[row][column] == 1) //If we encounter land, 
                {
                    TraverseBFSToClearAllConnectedLand(grid, row, column); //Eliminate all land attached to it so that we don't recount islands
                    count++; //Increment island count
                }
            }
        }

        return count;
    }

    #endregion

    #region Auxilliary Functions

    void TraverseBFSToClearAllConnectedLand(char[][] grid, int row, int column)
    {
        Queue<int[]> rowColumnPairQ = new Queue<int[]>();
        int[] currentRowColumnPair = new int[] { row, column };
        rowColumnPairQ.Enqueue(currentRowColumnPair);

        while (rowColumnPairQ.Count > 0)
        {
            int[] currentRCP = rowColumnPairQ.Dequeue();
            grid[currentRCP[0]][currentRCP[1]] = (char)0;

            //Going up
            if (CommonMethodsAndData.CheckIfWithinBounds(currentRCP[0] - 1, currentRCP[1], grid)) //Check if going up is possible
            {
                if (grid[currentRCP[0] - 1][currentRCP[1]] == 1) //Check if up there is land itself
                {
                    int[] upGoingRCP = new int[] { currentRCP[0] - 1, currentRCP[1] };
                    rowColumnPairQ.Enqueue(upGoingRCP);
                }
            }
            //Going right
            if (CommonMethodsAndData.CheckIfWithinBounds(currentRCP[0], currentRCP[1] + 1, grid)) //Check if going right is possible
            {
                if (grid[currentRCP[0]][currentRCP[1] + 1] == 1) //Check if right is land itself
                {
                    int[] rightGoingRCP = new int[] { currentRCP[0], currentRCP[1] + 1 };
                    rowColumnPairQ.Enqueue(rightGoingRCP);
                }
            }
            //Going down
            if (CommonMethodsAndData.CheckIfWithinBounds(currentRCP[0] + 1, currentRCP[1], grid)) //Check if going down is possible
            {
                if (grid[currentRCP[0] + 1][currentRCP[1]] == 1) //Check if down there is land itself
                {
                    int[] downGoingRCP = new int[] { currentRCP[0] + 1, currentRCP[1] };
                    rowColumnPairQ.Enqueue(downGoingRCP);
                }
            }
            //Going left
            if (CommonMethodsAndData.CheckIfWithinBounds(currentRCP[0], currentRCP[1] - 1, grid)) //Check if going left is possible
            {
                if (grid[currentRCP[0]][currentRCP[1] - 1] == 1) //Check if left is land itself
                {
                    int[] leftGoingRCP = new int[] { currentRCP[0], currentRCP[1] - 1 };
                    rowColumnPairQ.Enqueue(leftGoingRCP);
                }
            }
        }
    }

    #endregion
}