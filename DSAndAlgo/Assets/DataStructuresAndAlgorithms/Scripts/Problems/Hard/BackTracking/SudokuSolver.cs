
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
        SudokuSolver_Backtracking(board, 0, 0);
    }

    #region Private Methods

    private bool SudokuSolver_Backtracking(char[][] board, int row, int column)
    {
        //Reached the end? => We've completed the solution
        if (row == 9)
        {
            return true;
        }

        //Reached the end of a row? => Go to next row 
        if (column == 9)
        {
            return SudokuSolver_Backtracking(board, row + 1, 0);
        }

        //If not empty => Go to next cell
        if (board[row][column] != '.')
        {
            return SudokuSolver_Backtracking(board, row, column + 1);
        }
        //If empty => Put all possible values in this cell itself
        else
        {
            for (int i = 1; i <= 9; i++)
            {
                if (CurrentNumberValidityCheck(board, row, column, i))
                {
                    //char c = (char)i;
                    char c = i.ToString().ToCharArray()[0];
                    board[row][column] = c;
                    if (SudokuSolver_Backtracking(board, row, column + 1))
                    {
                        return true;
                    }
                    board[row][column] = '.';
                }
            }
        }

        return false;
    }

    private bool CurrentNumberValidityCheck(char[][] board, int row, int column, int currentNum)
    {
        char charToCheck = currentNum.ToString().ToCharArray()[0];

        //Performing col and row validity check in one iteration
        for (int i = 0; i < 9; i++)
        {
            //Column validity check
            if (board[row][i] == charToCheck)
            {
                return false;
            }

            //Row validity check
            if (board[i][column] == charToCheck)
            {
                return false;
            }
        }

        //Performing grid validity check
        int minRow = (int)((int)3 * Math.Floor((float)row / 3));
        int minCol = (int)((int)3 * Math.Floor((float)column / 3));

        for (int i = minRow; i < minRow + 3; i++)
        {
            for (int j = minCol; j < minCol + 3; j++)
            {
                if (board[i][j] == charToCheck)
                    return false;
            }
        }

        return true;
    }

    #endregion

    #endregion
}