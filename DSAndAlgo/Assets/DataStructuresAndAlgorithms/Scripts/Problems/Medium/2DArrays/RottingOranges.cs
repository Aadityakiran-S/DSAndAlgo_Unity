using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RottingOranges : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/rotting-oranges/

    //	You are given an m x n grid where each cell can have one of three values:

    //0 representing an empty cell,
    //1 representing a fresh orange, or
    //2 representing a rotten orange.
    //Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

    //Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.


    //Example 1:

    //Input: grid = [[2, 1, 1], [1,1,0], [0,1,1]]
    //Output: 4

    //Example 2:

    //Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
    //Output: -1
    //Explanation: The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.

    //Example 3:

    //Input: grid = [[0,2]]
    //Output: 0
    //Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

    //Constraints:

    //m == grid.length
    //n == grid[i].length
    //1 <= m, n <= 10
    //grid[i][j] is 0, 1, or 2.
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

    private int OrangesRotting(int[][] grid)
    {
        int freshCount = 0;
        Queue<int[]> rottenPos = new Queue<int[]>();

        //Sequential iteration through grid
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                if (grid[row][column] == 1) //Gathering all fresh count
                {
                    freshCount++;
                }
                else if (grid[row][column] == 2) //Storing initially rotten positions
                {
                    rottenPos.Enqueue(new int[] { row, column });
                }
            }
        }

        int count = rottenPos.Count;
        int timeToRot = 0;

        while (rottenPos.Count > 0)
        {
            if (count == 0)
            {
                count = rottenPos.Count;
                timeToRot++;
            }

            int[] currentPosition = rottenPos.Dequeue();

            foreach (int[] direction in CommonMethodsAndData.arrayDirections)
            {
                //Calculating position to go (up, right, down, left in that order)
                int[] positionToGo = new int[] { currentPosition[0] + direction[0], currentPosition[1] + direction[1] };

                if (CommonMethodsAndData.CheckIfWithinBounds(positionToGo[0], positionToGo[1], grid)) //If withing bounds
                {
                    if (grid[positionToGo[0]][positionToGo[1]] == 1) //Going position is not rotten
                    {
                        rottenPos.Enqueue(positionToGo); //enquing next position to start rotting from
                        grid[positionToGo[0]][positionToGo[1]] = 2; //Rotting that position
                        freshCount--; //decrementing fresh count
                    }
                }
            }

            count--;
        }

        if (freshCount > 0)
        {
            return -1;
        }
        else if (freshCount == 0)
        {
            return timeToRot; 
        }
        else
        {
            throw new Exception("Something has gone horribly wrong");
        }
    }

    #endregion
}