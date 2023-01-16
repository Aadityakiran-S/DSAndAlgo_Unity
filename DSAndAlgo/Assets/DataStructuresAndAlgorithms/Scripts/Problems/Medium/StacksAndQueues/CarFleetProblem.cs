using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CarFleetProblem : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/car-fleet/

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

    public int CarFleet(int target, int[] position, int[] speed)
    {
        int[][] posAndSpeeds = new int[position.Length][];
        int fleetCount = 0;

        //Grouping positions and speeds in one array as pairs 
        for (int i = 0; i < position.Length; i++)
        {
            posAndSpeeds[i] = new int[2] { position[i], speed[i] };
        }
        //Ordering the array by it's first element
        posAndSpeeds = posAndSpeeds.OrderBy(x => x[0]).ToArray();

        //Target is always given to be away from positions of all cars => time is always > 0
        float previousTime = 0;
        //Starting from the car that is the closest to the target and calculating times of arrival
        for (int i = posAndSpeeds.Length - 1; i >= 0 ; i--)
        {
            float currentTime = (float)(target - posAndSpeeds[i][0]) / posAndSpeeds[i][1];

            //Next car set to overtake? => They will contribute to the same fleet, no need to add
            if(currentTime <= previousTime)
            {
                continue;
            }
            else
            {
                fleetCount++;
                previousTime = currentTime;
            }
        }

        return fleetCount;
    }

    #endregion
}