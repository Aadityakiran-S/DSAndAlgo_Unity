using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonMethodsAndData
{
    #region References

    public static int[][] arrayDirections = new int[][]
    {
        new int [] { -1, 0 }, //up
        new int [] { 0, 1 }, //right
        new int [] { 1, 0 }, //down
        new int [] { 0, -1} //left
    };

    #endregion

    #region Methods

    public static void CheckIfIndexInBounds(int index, int Length)
    {
        if (!(index <= Length - 1 && index >= 0))
        {
            throw new System.ArgumentOutOfRangeException("index", "Index is either negative or out of the range of the list");
        }
    }

    public static bool CheckIfArrayIsSorted(int[] arrayToCheck, int length)
    {
        //Meaning of sorting only exists if more than 2 elements
        if (arrayToCheck.Length < 2) return true;

        //If prev element is greater than next, then it's not sorted, we can exit
        if (arrayToCheck[length - 2] > arrayToCheck[length - 1]) return false;

        //Otherwise, if we've reached end without incident, it is, we may again exit
        else if (length == 2) return true;

        //If prev conditions are traversed, check for one frame before end
        return CheckIfArrayIsSorted(arrayToCheck, length - 1);
    }

    public static void SwapElementsInArray<T>(T[] arrayFromWhichToSwap, int k, int v)
    {
        if(k > arrayFromWhichToSwap.Length - 1 || v > arrayFromWhichToSwap.Length - 1)
        {
            Debug.LogError("Index out of range");
            return;
        }

        T tempK = arrayFromWhichToSwap[k];
        T tempV = arrayFromWhichToSwap[v];

        arrayFromWhichToSwap[k] = tempV;
        arrayFromWhichToSwap[v] = tempK;
    }

    public static bool CheckIfWithinBounds<T>(int row, int column, T[][] input)
    {
        if (row < 0 || row > input.GetLength(0) - 1)
        {
            return false;
        }
        else if (column < 0 || column > input[0].Length - 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion
}
