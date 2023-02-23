using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KokoEatingBannanas : MonoBehaviour
{
	#region Question
	
	

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

    #region Public Functions
    public int MinEatingSpeed(int[] piles, int h)
    {
        //Finding max value in array and initializing possible rates array
        int maxP = ReturnMax(piles); int[] rates = new int[maxP];
        for (int i = 1; i <= maxP; i++)
        {
            rates[i - 1] = i;
        }

        //Setting  variables to do binary search. MaxP is the max possible rate, can only go down from there
        int left = 0; int right = rates.Length - 1; int minRate = maxP;
        while (left <= right)
        {
            int mid = (int)Math.Floor((double)(left + right) / 2);
            int timeToEat = ReturnTimeToEat(piles, rates[mid]);

            if (timeToEat > h)
            {
                left = mid + 1;
            }
            else
            { //time <= h
                minRate = Math.Min(minRate, rates[mid]);
                right = mid - 1;
            }
        }

        return minRate;
    }
    #endregion

    #region Helper Functions

    private int ReturnTimeToEat(int[] piles, int rate)
    {
        int time = 0;

        foreach (int entry in piles)
        {
            time += (int)Math.Ceiling((double)entry / rate);
        }

        return time;
    }

    private int ReturnMax(int[] input)
    {
        int max = int.MinValue;

        foreach (int entry in input)
        {
            max = Math.Max(max, entry);
        }

        return max;
    }

    #endregion
}