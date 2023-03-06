using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SurroundedRegions : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/surrounded-regions

    #endregion

    #region References

    int[][] _directions = new int[4][]{
        new int[] {-1, 0}, //Up
        new int[]{0, 1}, //Right
        new int[]{1, 0}, //Down
        new int[]{0, -1} //Left
    };

    #endregion

    #region Methods

    public void Solve(char[][] input)
    {
        bool[,] seen = new bool[input.Length, input[0].Length];

        //Top and bottom traversal
        for (int i = 0; i < input[0].Length; i++)
        {
            Traverse_DFS(input, new int[] { 0, i }, seen); //Top
            Traverse_DFS(input, new int[] { input.Length - 1, i }, seen); //Bottom
        }

        //Left and right traversal
        for (int i = 0; i < input.Length; i++)
        {
            Traverse_DFS(input, new int[] { i, 0 }, seen); //Left
            Traverse_DFS(input, new int[] { i, input[0].Length - 1 }, seen); //Right
        }

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (seen[i, j] == false)
                    input[i][j] = 'X';
            }
        }
    }

    private void Traverse_DFS(char[][] input, int[] currPos, bool[,] seen)
    {

        //Out of bounds
        if (currPos[0] < 0 || currPos[0] > input.Length - 1 || currPos[1] < 0 || currPos[1] > input[0].Length - 1)
        {
            return;
        }

        //Only consider 'O'
        if (input[currPos[0]][currPos[1]] == 'X')
        {
            return;
        }

        //No need to consider already seen elements even if they're 'O'
        if (seen[currPos[0], currPos[1]])
        {
            return;
        }

        seen[currPos[0], currPos[1]] = true; //Gathering all entries connected to initial entry

        foreach (var dir in _directions)
        {
            int[] dir2Go = new int[] { dir[0] + currPos[0], dir[1] + currPos[1] };
            Traverse_DFS(input, dir2Go, seen);
        }
    }

    #endregion
}