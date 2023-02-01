using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IslandWithMaxArea : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/max-area-of-island/

    #endregion

    #region References
    //4 Directions to travel in this array
    private int[][] _directions = new int[][]{
        new int[]{-1, 0}, //Up
        new int[]{0, 1},  //Right
        new int[]{1, 0},  //Down
        new int[]{0, -1} //Left
    };
    #endregion

    #region Public Methods

    public int MaxAreaOfIsland(int[][] grid)
    {
        bool[,] seen = new bool[grid.Length, grid[0].Length];
        int maxArea = 0;

        //Iterating through the 2D array serially
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                //If we encounter an unexplored piece of land => explore
                if (seen[i, j] != true && grid[i][j] == 1)
                {
                    maxArea = Math.Max(
                        FindAreaOfIsland_BFS(grid, seen, new int[] { i, j }),
                        maxArea);
                }
            }
        }

        return maxArea;
    }

    #endregion

    #region Private Methods

    private int FindAreaOfIsland_BFS(int[][] grid, bool[,] seen, int[] currentPos)
    {
        Queue<int[]> bfsQ = new Queue<int[]>(); bfsQ.Enqueue(currentPos); int area = 0;
        //Setting seen of entered element here : cannot set anywhere else
        seen[currentPos[0], currentPos[1]] = true;

        //Performing BFS
        while (bfsQ.Count > 0)
        {
            //Taking current out, incrementing area since we're exploring and
            //puttins seen as true since we're exploring 
            int[] curr = bfsQ.Dequeue(); area++;

            //Iterating through every possible direction
            foreach (int[] dir in _directions)
            {
                int[] toGo = new int[2] { curr[0] + dir[0], curr[1] + dir[1] };
                //Checking if toGo is within bounds of grid
                if (toGo[0] <= grid.Length - 1 && toGo[0] >= 0 &&
                    toGo[1] <= grid[0].Length - 1 && toGo[1] >= 0)
                {
                    //Checking if where we're going is an unseen piece of land
                    if (grid[toGo[0]][toGo[1]] == 1 && seen[toGo[0], toGo[1]] == false)
                    {
                        //Setting seen before entereing to prevent duplicate entry
                        seen[toGo[0], toGo[1]] = true;
                        bfsQ.Enqueue(toGo);
                    }
                }
            }
        }

        return area;
    }

    #endregion
}