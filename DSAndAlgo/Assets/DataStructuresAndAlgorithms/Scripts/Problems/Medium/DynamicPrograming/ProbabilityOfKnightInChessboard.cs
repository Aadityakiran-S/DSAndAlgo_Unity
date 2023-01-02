using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ProbabilityOfKnightInChessboard : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/knight-probability-in-chessboard/

    //On an n x n chessboard, a knight starts at the cell(row, column) and attempts to make exactly k moves.
    //The rows and columns are 0-indexed, so the top-left cell is (0, 0), and the bottom-right cell is (n - 1, n - 1).
    //A chess knight has eight possible moves it can make, as illustrated below.Each move is two cells in a cardinal direction,
    //then one cell in an orthogonal direction.
    //Each time the knight is to move, it chooses one of eight possible moves uniformly at random
    //(even if the piece would go off the chessboard) and moves there.
    //The knight continues moving until it has made exactly k moves or has moved off the chessboard.

    //Return the probability that the knight remains on the board after it has stopped moving.


    //Example 1:
    //Input: n = 3, k = 2, row = 0, column = 0
    //Output: 0.06250
    //Explanation: There are two moves(to (1,2), (2,1)) that will keep the knight on the board.
    //From each of those positions, there are also two moves that will keep the knight on the board.
    //The total probability the knight stays on the board is 0.0625.

    //Example 2:
    //Input: n = 1, k = 0, row = 0, column = 0
    //Output: 1.00000

    //Constraints:
    //1 <= n <= 25
    //0 <= k <= 100
    //0 <= row, column <= n - 1

    #endregion

    #region References
    int[][] knightDirections = new int[][]{
        new int[] { -2, -1},
        new int[] { -2, 1},
        new int[] { -1, -2},
        new int[] { -1, 2},
        new int[] { 1, -2},
        new int[] { 1, 2},
        new int[] { 2, -1},
        new int[] { 2, 1 }
    };

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

    public double KnightProbability(int n, int k, int r, int c)
    {
        //Are we out of the board? => Prob: of in the board is 0
        if (r < 0 || r > n - 1 || c < 0 || c > n - 1)
        {
            return 0;
        }

        //No more moves to make and we're inside the chessboard? => prob: of on board is 1
        if (k == 0)
        {
            return 1;
        }

        //Declaring 2 3D matrics for memoization
        double[,] dpPrev = new double[n, n]; 
        double[,] dpCurr = new double[n, n]; 
        dpPrev[r, c] = 1; //Setting 0th value to 1 (that's where we start from)

        for (int step = 1; step <= k; step++) //Step starts from 1 since we've done for zero already
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    foreach (int[] dir in knightDirections)
                    {
                        //We're checking if for each cell, what the prob is 
                        //to come from the previous cell which will basically compound in 1/8
                        int prevRow = row + dir[0];
                        int prevCol = column + dir[1];

                        //If prev cell is within bounds
                        if (prevRow >= 0 && prevRow <= n-1 && prevCol >= 0 && prevCol <= n - 1)
                        {
                            dpCurr[row, column] += (dpPrev[prevRow, prevCol] / 8);
                        }
                    }
                }
            }

            //Reinitializing arrays since we only need previous to determine next
            dpPrev = dpCurr;
            dpCurr = new double[n, n];
        }

        //Shifting latest values to current DP matrix
        dpCurr = dpPrev;

        double result = 0;
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                result += dpCurr[row, column];
            }
        }

        return result;
    }

    public double KnightProbability_Iterative_SubOptimal(int n, int k, int r, int c)
    {
        //Are we out of the board? => Prob: of in the board is 0
        if (r < 0 || r > n - 1 || c < 0 || c > n - 1)
        {
            return 0;
        }

        //No more moves to make and we're inside the chessboard? => prob: of on board is 1
        if (k == 0)
        {
            return 1;
        }

        //Declaring an empty 3D matrix with prob values in each cell
        //for each value of K also
        double[,,] dp = new double[k + 1, n, n]; //Arrays are indexed from zero but k is from 1
        dp[0, r, c] = 1; //Setting 0th value to 1 (that's where we start from)

        for (int step = 1; step <= k; step++) //Step starts from 1 since we've done for zero already
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    foreach (int[] dir in knightDirections)
                    {
                        //We're checking if for each cell, what the prob is 
                        //to come from the previous cell which will basically compound in 1/8
                        int prevRow = row + dir[0];
                        int prevCol = column + dir[1];

                        //If prev cell is within bounds
                        if (prevRow >= 0 && prevRow <= n - 1 && prevCol >= 0 && prevCol <= n - 1)
                        {
                            dp[step, row, column] += (dp[step - 1, prevRow, prevCol] / 8);
                        }
                    }
                }
            }
        }

        double result = 0;
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                result += dp[k, row, column];
            }
        }

        return result;
    }

    public double KnightProbability_Recursive(int n, int k, int r, int c)
    {
        //Declaring an empty 3D matrix with prob values in each cell
        //for each value of K also
        double[,,] values = new double[k + 1, n, n]; //Arrays are indexed from zero but k is from 1

        //Filling all values as -1 by default
        for (int i = 0; i < values.GetLength(0); i++)
        {
            for (int j = 0; j < values.GetLength(1); j++)
            {
                for (int l = 0; l < values.GetLength(3); l++)
                {
                    values[i, j, l] = -1;
                }
            }
        }

        return KnightRecurse(n, k, r, c, values);
    }

    private double KnightRecurse(int n, int k, int r, int c, double[,,] values)
    {
        //Are we out of the board? => Prob: of in the board is 0
        if (r < 0 || r > n - 1 || c < 0 || c > n - 1)
        {
            return 0;
        }

        //No more moves to make and we're inside the chessboard? => prob: of on board is 1
        if (k == 0)
        {
            return 1;
        }

        if (values[k, r, c] != -1)
        {
            return values[k, r, c];
        }

        double result = 0;

        for (int i = 0; i < knightDirections.Length; i++)
        {
            int[] dir = knightDirections[i];
            result += KnightProbability_Iterative_SubOptimal(n, k - 1, r + dir[0], c + dir[1]) / 8;
        }

        values[k, r, c] = result;

        return result;
    }

    #endregion
}