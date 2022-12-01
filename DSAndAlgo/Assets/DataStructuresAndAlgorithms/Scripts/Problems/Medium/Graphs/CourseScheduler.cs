using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CourseScheduler : MonoBehaviour
{
    #region Question

    //There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
    //You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course
    //bi first if you want to take course ai.

    //For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    //Return true if you can finish all courses.Otherwise, return false.

    //Example 1:

    //Input: numCourses = 2, prerequisites = [[1, 0]]
    //Output: true
    //Explanation: There are a total of 2 courses to take.
    //To take course 1 you should have finished course 0. So it is possible.

    //Example 2:

    //Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
    //Output: false
    //Explanation: There are a total of 2 courses to take.
    //To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


    //Constraints:

    //1 <= numCourses <= 2000
    //0 <= prerequisites.length <= 5000
    //prerequisites[i].length == 2
    //0 <= ai, bi<numCourses
    //All the pairs prerequisites[i] are unique.

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

    #region Exposed Methods

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        int[][] adjacencyList = Return_AdjacencyList(numCourses, prerequisites);

        return false;
    }

    #endregion

    #region Unexposed Methods

    private int[][] Return_AdjacencyList(int numCourses, int[][] prerequisites)
    {
        List<int>[] adjacencyList = new List<int>[numCourses];

        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (adjacencyList[prerequisites[i][1]] == null) //Array at index is not initialized yet
            {
                List<int> tempList = new List<int>();
                adjacencyList[prerequisites[i][1]] = tempList;
            }

            adjacencyList[prerequisites[i][1]].Add(prerequisites[i][0]);
        }

        int[][] finalAdjacencyList = new int[numCourses][];
        for (int i = 0; i < adjacencyList.Length; i++)
        {
            if (adjacencyList[i] == null) //If adjacency list has nothing in a particular spot
            {
                finalAdjacencyList[i] = new int[0]; //Sub with an empty array
            }
            else //If it has something, then convert that thing to an arry and put into new collection
            {
                finalAdjacencyList[i] = adjacencyList[i].ToArray();
            }
        }

        return finalAdjacencyList;
    }

    #endregion
}