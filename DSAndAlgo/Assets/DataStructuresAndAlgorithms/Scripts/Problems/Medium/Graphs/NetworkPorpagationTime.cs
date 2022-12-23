using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NetworkPorpagationTime : MonoBehaviour
{
    #region Question

    //Question Link: https://leetcode.com/problems/network-delay-time/

    //You are given a network of n nodes, labeled from 1 to n.
    //You are also given times, a list of travel times as directed edges times[i] = (ui, vi, wi),
    //where ui is the source node, vi is the target node, and wi is the time it takes for a signal to travel from source to target.

    //We will send a signal from a given node k. Return the minimum time it takes for all the n
    //nodes to receive the signal. If it is impossible for all the n nodes to receive the signal, return -1.

    //Example 1:

    //Input: times = [[2, 1, 1], [2,3,1], [3,4,1]], n = 4, k = 2
    //Output: 2

    //Example 2:

    //Input: times = [[1,2,1]], n = 2, k = 1
    //Output: 1

    //Example 3:

    //Input: times = [[1,2,1]], n = 2, k = 2
    //Output: -1

    //Constraints:

    //1 <= k <= n <= 100
    //1 <= times.length <= 6000
    //times[i].length == 3
    //1 <= ui, vi <= n
    //ui != vi
    //0 <= wi <= 100
    //All the pairs(ui, vi) are unique. (i.e., no multiple edges.)


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

    public int NetworkDelayTime_BellmanFord(int[][] times, int n, int k)
    {
        //Initializing distances array
        int[] distances = new int[n];
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[k - 1] = 0;

        //Iterating n times through according to Bellamn-Ford
        for (int i = 0; i < n; i++)
        {
            foreach (int[] entry in times)
            {
                if(distances[entry[1] - 1] > distances[entry[0] - 1] + entry[2])
                {
                    distances[entry[1] - 1] = distances[entry[0] - 1] + entry[2];
                }
            }
        }

        //Finding max distance
        int maxDistance = int.MinValue;
        for (int i = 0; i < distances.Length; i++)
        {
            if(distances[i] > maxDistance)
            {
                maxDistance = distances[i];
            }
        }

        return (maxDistance == int.MaxValue) ? -1 : maxDistance;
    }
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        //Declaring distances array
        int[] distances = new int[n];
        for (int i = 0; i < n; i++) //Fillin with infinity
        {
            distances[i] = int.MaxValue;
        }

        bool[] seen = new bool[n]; //Declaring seen array
        int current = k; //times array goes from 1-n while our arrays start from 0
        distances[current - 1] = 0; //Setting starting index distance to zero


        while (true)
        {
            seen[current - 1] = true;
            for (int i = 0; i < times.GetLength(0); i++)
            {
                if (times[i][0] == current) //Starting from our current
                {
                    //Next connection's weight compared to current plus distance to next
                    if (distances[times[i][1] - 1] > distances[current - 1] + times[i][2])
                    {
                        distances[times[i][1] - 1] = distances[current - 1] + times[i][2];
                    }
                }
            }

            int[] seenValuePair = new int[] { 0, int.MaxValue };

            //Iterating through distance array to find min unseen value
            for (int i = 0; i < distances.Length; i++)
            {
                if (seen[i] == false) //Unseen value
                {
                    //Finding min distance 
                    if (distances[i] < seenValuePair[1])
                    {
                        seenValuePair[0] = i; seenValuePair[1] = distances[i];
                    }
                }
            }

            //If min unseen is infinity => loop exists
            if (seenValuePair[1] == int.MaxValue)
                break;
            else
                current = seenValuePair[0] + 1; //Adjusting for offset between input index and our index
        }

        int maxValue = distances.Max();

        return (maxValue == int.MaxValue) ? -1 : maxValue;
    }

    #endregion
}