using System;
using System.Collections;
using System.Collections.Generic;

public class Custom2DArray
{
    #region References and Constructor



    #endregion

    #region Public Methods

    public object[] Populate_2DDFSArray_Optimal(object[,] inputArray)
    {
        RowColumnPair maxRCP = new RowColumnPair(inputArray.GetLength(0) - 1, inputArray.GetLength(1) - 1);
        RowColumnPair currentRC = new RowColumnPair();

        bool[,] seenMatrixValues = new bool[maxRCP.row, maxRCP.column];
        object[] outputArray = new object[maxRCP.row * maxRCP.column];

        DFS_2DArrayRecursive_Optimal(inputArray, currentRC, maxRCP, outputArray, seenMatrixValues);

        return outputArray;
    }

    public object[] Populate_2DBFSArray(object[,] inputArray)
    {
        //Declaring max values of indices and middle value to start BFS from
        RowColumnPair maxRCP = new RowColumnPair(inputArray.GetLength(0) - 1, inputArray.GetLength(1) - 1);
        RowColumnPair middleRCP = new RowColumnPair((int)Math.Floor((double)inputArray.GetLength(0) - 1), 
            (int)Math.Floor((double)inputArray.GetLength(0) - 1));

        //Declaring queue, outputArrary and seenIndices matrix to keep track of seen values
        Queue<RowColumnPair> elementQueue = new Queue<RowColumnPair>();
        object[] outputArray = new object[inputArray.GetLength(0) * inputArray.GetLength(1)];
        bool[,] seenIndices = new bool[inputArray.GetLength(0) - 1, inputArray.GetLength(1) - 1];

        //Starting with middle element
        elementQueue.Enqueue(middleRCP);

        //Iterating BFS
        while (elementQueue.Count > 0)
        {
            RowColumnPair current = elementQueue.Dequeue();

            //Adding to output array and updating seen array
            AddToFirstFreeSlot(outputArray, inputArray[current.row, current.column]);
            seenIndices[current.row, current.column] = true;

            foreach (MatrixDFSDirections direction in Enum.GetValues(typeof(MatrixDFSDirections)))
            {
                RowColumnPair directionToGo = current.MoveToDirection(direction);

                //If neighbor is not explored and within bounds, add to queue to process later
                if (CheckIfWithinBounds(directionToGo, maxRCP) && !seenIndices[directionToGo.row, directionToGo.column])
                {
                    elementQueue.Enqueue(directionToGo);
                }
            }
        }

        return outputArray;
    }

    #endregion

    #region Helper Methods

    void DFS_2DArrayRecursive_Optimal(object[,] input, RowColumnPair currentPos, RowColumnPair maxPos,
        object[] outputArray, bool[,] seenMatrixElements)
    {
        //Base case: When direction is out of bounds or at an element already seen
        if (!CheckIfWithinBounds(currentPos, maxPos) || seenMatrixElements[currentPos.row, currentPos.column])
        {
            return;
        }

        //Setting seen value and adding current element to output array
        seenMatrixElements[currentPos.row, currentPos.column] = true;
        AddToFirstFreeSlot(outputArray, input[currentPos.row, currentPos.column]);

        //Recursively calling for each direction
        foreach (MatrixDFSDirections direction in Enum.GetValues(typeof(MatrixDFSDirections)))
        {
            RowColumnPair directionToGo = currentPos.MoveToDirection(direction);
            DFS_2DArrayRecursive_Optimal(input, directionToGo, maxPos, outputArray, seenMatrixElements);
        }
    }

    bool CheckIfWithinBounds(RowColumnPair positionToCheck, RowColumnPair maxPos)
    {
        if (positionToCheck.row > maxPos.row || positionToCheck.row < 0)
            return false;
        else if (positionToCheck.column > maxPos.column || positionToCheck.column < 0)
            return false;

        return true;
    }

    void AddToFirstFreeSlot(object[] outputArray, object objToAdd)
    {
        for (int i = 0; i < outputArray.Length; i++)
        {
            if (outputArray[i] == null)
            {
                outputArray[i] = objToAdd;
                break;
            }
        }
    }

    #endregion
}

public struct RowColumnPair
{
    public int row;
    public int column;

    public RowColumnPair(int row = 0, int column = 0)
    {
        this.row = row;
        this.column = column;
    }

    public RowColumnPair(RowColumnPair pair)
    {
        this.row = pair.row;
        this.column = pair.column;
    }

    public RowColumnPair MoveToDirection(MatrixDFSDirections direction)
    {
        RowColumnPair rcp = new RowColumnPair();

        switch (direction)
        {
            case MatrixDFSDirections.Up:
                rcp = new RowColumnPair(this.row - 1, this.column);
                break;
            case MatrixDFSDirections.Right:
                rcp = new RowColumnPair(this.row, this.column + 1);
                break;
            case MatrixDFSDirections.Down:
                rcp = new RowColumnPair(this.row + 1, this.column);
                break;
            case MatrixDFSDirections.Left:
                rcp = new RowColumnPair(this.row, this.column - 1);
                break;
            default:
                break;
        }

        return rcp;
    }
}

public enum MatrixDFSDirections
{
    Up = 1, Right = 2, Down = 3, Left = 4
}
