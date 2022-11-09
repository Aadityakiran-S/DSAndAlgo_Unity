using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WallsAndGates_Problem : MonoBehaviour
{
    #region Question
    //Question Link: https://www.lintcode.com/problem/663/

    //	You are given a m x n 2D grid initialized with these three possible values.

    //-1 - A wall or an obstacle. 0 - A gate.INF - Infinity means an empty room.We use the value 231 - 1 = 2147483647
    //to represent INF as you may assume that the distance to a gate is less than 2147483647.
    //Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.

    //For example, given the 2D grid:

    //INF  -1  0  INF
    //INF INF INF  -1
    //INF  -1 INF  -1
    //  0  -1 INF INF

    //After running your function, the 2D grid should be:

    //  3  -1   0   1
    //  2   2   1  -1
    //  1  -1   2  -1
    //  0  -1   3   4

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

    private int[][] WallsAndGates_BFS(int[][] rooms)
    {
        Queue<int[]> gatePositions = new Queue<int[]>();

        //Sequential iteration through rooms to get all Gate positions
        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms[row].Length; column++)
            {
                if (rooms[row][column] == 0) //Encountered a Gate
                {
                    gatePositions.Enqueue(new int[2] { row, column });
                }
            }
        }

        //Working backwards from Gates to fill cells
        while (gatePositions.Count > 0)
        {
            TraverseBFS_InRooms(rooms, gatePositions);
        }

        return rooms;
    }

    private int[][] WallsAndGames_DFS(int[][] rooms)
    {
        List<int[]> gatePositions = new List<int[]>();

        //Sequential iteration through rooms to get all Gate positions
        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms[row].Length; column++)
            {
                if (rooms[row][column] == 0) //Encountered a Gate
                {
                    gatePositions.Add(new int[2] { row, column });
                }
            }
        }

        foreach (int[] pos in gatePositions)
        {
            int steps = 1;
            TraverseDFS_InRooms(rooms, pos, steps);
        }

        return rooms;
    }

    void TraverseDFS_InRooms(int[][] rooms, int[] startPosition, int steps)
    {
        foreach (int[] dir in CommonMethodsAndData.arrayDirections)
        {
            int[] dirToGo = new int[2] { startPosition[0] + dir[0], startPosition[1] + dir[1] };

            if(CheckIfValidRoomToTraverse(dirToGo, rooms, steps))
            {
                rooms[dirToGo[0]][dirToGo[1]] = steps;
                TraverseDFS_InRooms(rooms, dirToGo, steps + 1);
            }
        }
    }

    void TraverseBFS_InRooms(int[][] rooms, Queue<int[]> gatePositions)
    {
        //Populating initial value for BFS to take place
        Queue<int[]> bfsQueue = new Queue<int[]>(); bfsQueue.Enqueue(gatePositions.Dequeue());

        int steps = 1; int count = bfsQueue.Count;

        while (bfsQueue.Count > 0)
        {
            if (count == 0)
            {
                count = bfsQueue.Count;
                steps++;
            }

            int[] currentPosition = bfsQueue.Dequeue();

            foreach (int[] dir in CommonMethodsAndData.arrayDirections)
            {
                int[] dirToGo = new int[2] { currentPosition[0] + dir[0], currentPosition[1] + dir[1] };

                if(CheckIfValidRoomToTraverse(dirToGo, rooms, steps))
                {
                    rooms[dirToGo[0]][dirToGo[1]] = steps;
                    bfsQueue.Enqueue(dirToGo);
                }
            }

            count--;
        }
    }

    //Return false if we go out, hit a wall or a gate or hit a value less than steps
    bool CheckIfValidRoomToTraverse(int[] posToGo, int[][] rooms, int steps)
    {
        int maxRow = rooms.GetLength(0) - 1;
        int maxColumn = rooms[0].Length - 1;

        //Checking if row out of bounds
        if (posToGo[0] > maxRow || posToGo[0] < 0)
        {
            return false;
        }
        //Check if column out of bounds
        else if (posToGo[1] > maxColumn || posToGo[1] < 0)
        {
            return false;
        }
        //Checking if hit wall, gate or less number
        else if (rooms[posToGo[0]][posToGo[1]] < steps)
        {
            return false;
        }

        return true;
    }

    #endregion
}