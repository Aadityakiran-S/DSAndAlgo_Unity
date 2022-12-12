using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CourseScheduler : MonoBehaviour
{
    #region Question

    //Question Link: https://leetcode.com/problems/course-schedule/

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

    public int[][] prerequisites;
    public int numCourses;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        Debug.Log(CanFinish_DFS(numCourses, prerequisites));
    }

    #endregion

    #region Exposed Methods

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        //Declaring all variables
        int index = -1; 
        int[][] adjList = Return_AdjacencyList(numCourses, prerequisites);
        int[] inDegree = Return_InDegreeArray(numCourses, prerequisites);
        bool[] seen = new bool[numCourses];

        while (true) //Taking out isolated nodes
        {
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 0 && seen[i] == false) //Capturing the first unseen 0 ie: first isolated node
                {
                    //This is the index of the first unseen zero (node with inDegree zero/isolated node)
                    index = i;
                    seen[i] = true; //Now it's a seen zero
                    break; //Found? then break out of for-loop
                }

                index = -1; //If no isolated nodes are there
            }

            if (index == -1) //Finished seeing all unseen zeroes?
            {
                break; //Break out of while-loop
            }

            //The elements connected to the current isolated node
            int[] current = adjList[index];

            //Removing that isolated node ie: decrementing indegree of eaech of it's connections
            for (int j = 0; j < current.Length; j++)
            {
                if (inDegree[current[j]] > 0) //No need to decrement if already zero
                {
                    inDegree[current[j]] -= 1;
                }
            }
        }

        //If inDegree has even one nonzero element, then there exists a loop => course not possible
        return CheckIfAllElementsAreZero(inDegree);
    }

    public bool CanFinish_DFS(int numCourses, int[][] prerequisites)
    {
        //No dependencies => Can surely finish
        if (numCourses == 1)
        {
            return true;
        }

        int[][] adjacencyList = Return_AdjacencyList(numCourses, prerequisites);
        bool[] seen = new bool[numCourses];

        for (int i = 0; i < numCourses; i++) //Performing DFS on each element of AdjList
        {
            //Any one element DFS returns false => cannot complete course
            if (DFS_ReturnIsCoursePossible(adjacencyList, i, seen) == false)
            {
                return false;
            }
        }

        return true; //None of the elements DFS return false => Can complete course
    }

    public bool CanFinish_BFS(int numCourses, int[][] prerequisites)
    {
        //No dependencies => Can surely finish
        if (numCourses == 1)
        {
            return true;
        }

        int[][] adjacencyList = Return_AdjacencyList(numCourses, prerequisites);

        return BFS_ReturnIsCoursePossible(adjacencyList, numCourses);
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

    private int[] Return_InDegreeArray(int numCourses, int[][] prerequisites)
    {
        int[] inDegree = new int[numCourses];

        for (int i = 0; i < prerequisites.Length; i++)
        {
            int incomingConnection = prerequisites[i][0]; //The node with the incoming connection
            inDegree[incomingConnection] += 1;
        }

        return inDegree;
    }

    private bool DFS_ReturnIsCoursePossible(int[][] adjacencyList, int index, bool[] seen)
    {
        //Base case is when one path terminates or when we've reached a loop
        if (adjacencyList[index] == null) //We have reached the end of our loop (nowhere left to go)
        {
            //Resetting seen array since we're going to start the iteration again
            for (int i = 0; i < seen.Length; i++)
            {
                seen[i] = false;
            }
            return true;
        }
        else if (seen[index] == true) //If we've come across this element before, we've made a loop
        {
            return false;
        }

        seen[index] = true; //Setting this element as seen
        int[] connections = adjacencyList[index];
        for (int i = 0; i < connections.Length; i++)
        {
            //If recursion for further steps returns false, then exit out of stack 
            if (DFS_ReturnIsCoursePossible(adjacencyList, connections[i], seen) == false)
            {
                return false;
            }
            else //Otherwise continue exploring next element
            {
                continue;
            }
        }

        return true; //Once we've reached the end of a path
    }

    private bool BFS_ReturnIsCoursePossible(int[][] adjacencyList, int numCourses)
    {
        for (int i = 0; i < numCourses; i++) //Performing BFS starting on every element of the AdjList
        {
            Queue<int> bfsQeueu = new Queue<int>();
            bool[] seen = new bool[numCourses];

            int[] current = adjacencyList[i];
            for (int j = 0; j < current.Length; j++) //Pushing first element memebers into Q to start BFS
            {
                bfsQeueu.Enqueue(current[j]);
            }

            while (bfsQeueu.Count > 0)
            {
                int currentElement = bfsQeueu.Dequeue();
                seen[currentElement] = true;

                if (currentElement == i) //If already seen, we can't do course
                {
                    return false;
                }

                int[] adjacent = adjacencyList[currentElement];
                for (int k = 0; k < adjacent.Length; k++)
                {
                    int next = adjacent[k];
                    if (!seen[next])
                    {
                        bfsQeueu.Enqueue(next);
                    }
                }

            }
        }

        return true; //If after performing BFS, we didn't run into any issues, course can be completed
    }

    private bool CheckIfAllElementsAreZero(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                return false; //One non-zero element exists
            }
        }

        return true;
    }

    #endregion
}