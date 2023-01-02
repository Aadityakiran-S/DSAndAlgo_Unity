
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SudokuSolver : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/sudoku-solver/
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

    #region Public Methods	

    public void SolveSudoku(char[][] board)
    {
        for (int i = 1; i <= board.GetLength(0); i++)
        {
            SudokuSolver_Backtracking(board, 0, 0, i);
        }
    }

    #region Private Methods

    private void SudokuSolver_Backtracking(char[][] input, int row, int column, int currentNum)
    {
        //Condition for out of bounds
        if (row == -1 || column == -1)
        {
            return;
        }

        //If current number does not pass row, column and grid validity check
        if (!CurrentNumberValidityCheck(input, row, column, currentNum))
        {
            return;
        }

        input[row][column] = (char)currentNum; //Adding the current number if valid

        int[] nextValidCell = Return_NextEmptyCell(input, row, column);
        for (int i = 1; i < 10; i++)
        {
            SudokuSolver_Backtracking(input, nextValidCell[0], nextValidCell[1], i);
        }

        //Removing the char if invalid 
        input[row][column] = ',';
    }

    private int[] Return_NextEmptyCell(char[][] input, int row, int column)
    {
        int[] validCell = new int[2] { -1, -1 };

        while (row < 10)
        {
            while (column < 10)
            {
                if (input[row][column] == ',')
                {
                    validCell = new int[] { row, column };
                    return validCell;
                }

                column++;
            }

            row++;
            column = 0;
        }

        return validCell;
    }

    private bool CurrentNumberValidityCheck(char[][] input, int row, int column, int currentNum)
    {
        if (ColumnValidity(input, row, currentNum) && RowValidity(input, column, currentNum)
            && GridValidity(input, row, column, currentNum))
        {
            return true;
        }

        return false;
    }

    private bool GridValidity(char[][] input, int row, int column, int currentNum)
    {
        //Finding the starting index of the grid that [r,c] belongs to
        int minRow = (int)(3 * Decimal.Truncate(row / 3));
        int minCol = (int)(3 * Decimal.Truncate(column / 3));

        //Iterating within the grid only (from the element to 2 added to the element)
        for (int i = minRow; i < minRow + 2; i++)
        {
            for (int j = minCol; j < minCol + 2; j++)
            {
                if (input[i][j] == currentNum)
                {
                    return false;
                }
            }
        }

        return true;
    }

    //Check all rows for current num
    private bool RowValidity(char[][] input, int column, int currentNum)
    {
        for (int i = 0; i < input.GetLength(0); i++)
        {
            if (input[i][column] == currentNum)
            {
                return false;
            }
        }

        return true;
    }

    //Check all columns for current num
    private bool ColumnValidity(char[][] input, int row, int currentNum)
    {
        for (int i = 0; i < input.GetLength(1); i++)
        {
            if (input[row][i] == currentNum)
            {
                return false;
            }
        }

        return true;
    }

    #endregion

    #endregion
}