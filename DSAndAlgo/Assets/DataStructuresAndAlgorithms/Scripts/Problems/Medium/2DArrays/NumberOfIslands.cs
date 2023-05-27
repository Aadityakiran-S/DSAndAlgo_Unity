using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NumberOfIslands : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/number-of-islands/    
    #endregion

    #region Solution 1 (BFS method)    

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
                    //Eliminate all land attached to it so that we don't recount islands
                    TraverseBFSToClearAllConnectedLand(grid, row, column);
                    count++; //Increment island count
                }
            }
        }

        return count;
    }

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

    #region Solution 2 (BFS using Tuple)

    //(int row, int column)[] dir = new[]{
    //    (-1, 0), (0, -1), (1, 0), (0, 1)
    //};
    //bool[,] seen;

    //public int NumIslands_UsingTuple(char[][] grid)
    //{
    //    int m = grid.Length; int n = grid[0].Length; seen = new bool[m, n];
    //    int numberOfIslands = 0;
    //    for (int i = 0; i < m; i++)
    //    {
    //        for (int j = 0; j < n; j++)
    //        {
    //            if (grid[i][j] == '1' && !seen[i, j])
    //            {
    //                Explore(new(i, j), grid);
    //                numberOfIslands++;
    //            }
    //        }
    //    }
    //    return numberOfIslands;
    //}

    //void Explore((int row, int col) currentIsland, char[][] grid)
    //{
    //    Queue<(int row, int col)> bfsQ = new(); bfsQ.Enqueue(currentIsland);
    //    int m = grid.Length; int n = grid[0].Length;

    //    while (bfsQ.Count > 0)
    //    {
    //        (int row, int col) curr = bfsQ.Dequeue();
    //        seen[curr.row, curr.col] = true; //Marking current land as visited

    //        //Checking all 4 directions we could go from current land
    //        foreach ((int row, int col) entry in dir)
    //        {
    //            (int row, int col) dir2Go = new(entry.row + curr.row, entry.col + curr.col);
    //            //dir2Go is within bounds and an unexplored piece of land
    //            if (dir2Go.row >= 0 && dir2Go.col >= 0 && dir2Go.row < m && dir2Go.col < n &&
    //                seen[dir2Go.row, dir2Go.col] == false && grid[dir2Go.row][dir2Go.col] == '1')
    //            {
    //                bfsQ.Enqueue(dir2Go); //Add to queue for continued exploration 
    //            }
    //        }
    //    }
    //}

    #endregion
}