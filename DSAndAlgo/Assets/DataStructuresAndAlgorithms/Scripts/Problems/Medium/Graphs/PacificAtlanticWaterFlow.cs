using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PacificAtlanticWaterFlow : MonoBehaviour
{
    #region Question

    private int[][] _directions = new int[][]{
        new int[] {-1, 0}, //up
        new int[] {0, 1}, //right
        new int[] {1, 0}, //down
        new int[] {0, -1} //left
    };

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

    
    public IList<IList<int>> PacificAtlantic(int[][] input)
    {
        List<IList<int>> output = new List<IList<int>>();
        int m = input.Length; int n = input[0].Length;
        bool[,] pacSeen = new bool[m, n]; bool[,] atlSeen = new bool[m, n];

        //Doing BFS on top and bootom
        for (int i = 0; i < n; i++)
        {
            // BFS(input, pacSeen, new int[]{0, i}); //Pacific: TOP
            // BFS(input, atlSeen, new int[]{m - 1, i}); //Atlantic: BOTTOM

            DFS(0, i, input, pacSeen, input[0][i]);
            DFS(m - 1, i, input, atlSeen, input[m - 1][i]);
        }
        //Doing BFS on left and right
        for (int i = 0; i < m; i++)
        {
            // BFS(input, pacSeen, new int[]{i, 0}); //Pacific: LEFT
            // BFS(input, atlSeen, new int[]{i, n - 1}); //Atlantic: RIGHT

            DFS(i, 0, input, pacSeen, input[i][0]);
            DFS(i, n - 1, input, atlSeen, input[i][n - 1]);
        }

        //Adding all values into output which have concurrance in pacSeen and atlSeen
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (pacSeen[i, j] == true && atlSeen[i, j] == true)
                {
                    output.Add(new List<int> { i, j });
                }
            }
        }

        return output;
    }

    #endregion

    #region Helper Methods	

    //Doing BFS towards the direction of increasing height to know which cells
    //can drain to either ocean starting from
    private void BFS(int[][] input, bool[,] seen, int[] currPos)
    {
        Queue<int[]> bfsQ = new Queue<int[]>(); bfsQ.Enqueue(currPos);

        while (bfsQ.Count > 0)
        {
            int[] curr = bfsQ.Dequeue();
            seen[curr[0], curr[1]] = true;

            foreach (int[] dir in _directions)
            {
                int[] dir2Go = new int[] { dir[0] + curr[0], dir[1] + curr[1] };

                //Eliminating out of bounds, seen once already and less height cells
                if (dir2Go[0] >= input.Length || dir2Go[1] >= input[0].Length ||
                    dir2Go[0] < 0 || dir2Go[1] < 0 ||
                    input[dir2Go[0]][dir2Go[1]] < input[curr[0]][curr[1]] ||
                    seen[dir2Go[0], dir2Go[1]] == true)
                {

                    continue;
                }
                //If all checks pass, adding back to bfsQ to continue BFS
                else
                {
                    bfsQ.Enqueue(dir2Go);
                }
            }
        }
    }

    private void DFS(int row, int col, int[][] heights, bool[,] visits, int prev)
    {
        int m = heights.Length, n = heights[0].Length;
        if (row < 0 || row >= m || col < 0 || col >= n || visits[row, col] || heights[row][col] < prev)
            return;
        visits[row, col] = true;
        DFS(row, col + 1, heights, visits, heights[row][col]);
        DFS(row, col - 1, heights, visits, heights[row][col]);
        DFS(row + 1, col, heights, visits, heights[row][col]);
        DFS(row - 1, col, heights, visits, heights[row][col]);
    }

    #endregion
}