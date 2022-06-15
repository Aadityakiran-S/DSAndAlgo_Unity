using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRecurringEntry : MonoBehaviour
{
    #region References 

    [SerializeField] private int[] _recurringPairArray;

    List<ReccuringEntryDistancePair> entryDistancePairList = new List<ReccuringEntryDistancePair>();

    [System.Serializable]
    private struct ReccuringEntryDistancePair
    {
        public int entry;
        public int distance;

    }

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        ReturnFirstReccuringPair2_BruteForce(_recurringPairArray);
    }

    #endregion

    #region Methods

    //For the array [1, 2, 5, 5, 2, 9] returns 2
    private int ReturnFirstReccuringPair1_BruteForce(int[] array)
    {
        #region Error Check
        if (array.Length < 1)
        {
            Debug.Log("Array has nothing in it");
            return default;
        }
        else if (array.Length == 1)
        {
            Debug.Log("Array has only one element, so no chance of reccuring");
            return default;
        }
        #endregion

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    Debug.Log("First element that is duplicate is " + array[i]);
                    return array[i];
                }
            }
        }

        Debug.Log("All elements unique");
        return default;
    }

    //For the array [1, 2, 5, 5, 2, 9] returns 5
    private int ReturnFirstReccuringPair2_BruteForce(int[] array)
    {
        #region Error Check
        if (array.Length < 1)
        {
            Debug.Log("Array has nothing in it");
            return default;
        }
        else if (array.Length == 1)
        {
            Debug.Log("Array has only one element, so no chance of reccuring");
            return default;
        }
        #endregion

        //List<ReccuringEntryDistancePair> entryDistancePairList = new List<ReccuringEntryDistancePair>();

        //Iterating through entire list to find all pairs of reccuring entries
        for (int i = 0; i < array.Length; i++)  //O(n^2)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    Debug.Log("First element that is duplicate is " + array[i] + "\n with distance: " + (j - i));
                    ReccuringEntryDistancePair reccuringEntryAndDistance = new ReccuringEntryDistancePair
                    {
                        entry = array[i],
                        distance = j - i
                    };
                    entryDistancePairList.Add(reccuringEntryAndDistance);
                }
            }
        }

        //No entries in list => List has all unique entries
        if (entryDistancePairList.Count == 0)
        {
            Debug.Log("All elements unique");
            return default;
        }
        //Yes entries => iterate thruogh reccuringPairList and find pair with Least distance
        else
        {
            int currentDistance = array.Length;
            int reccuringPair = 0;
            foreach (ReccuringEntryDistancePair pairDist in entryDistancePairList)
            {
                if (pairDist.distance < currentDistance)
                {
                    currentDistance = pairDist.distance;
                    reccuringPair = pairDist.entry;
                }
            }

            Debug.Log("First recuring pair is " + reccuringPair);
            return reccuringPair;
        }

    }

    //For the array [1, 2, 5, 5, 2, 9] make it return 5
    private int ReturnFirstReccuringPair1(int[] array)
    {
        #region Error Check
        if (array.Length < 1)
        {
            Debug.Log("Array has nothing in it");
            return default;
        }
        else if (array.Length == 1)
        {
            Debug.Log("Array has only one element, so no chance of reccuring");
            return default;
        }
        #endregion

        Hashtable reccuringEntryTable = new Hashtable();
        foreach (int entry in array)
        {
            //Check if hashTable already has the entry
            if (reccuringEntryTable.Contains(entry))
            {
                //We have a match
                Debug.Log("First reccuring pair is " + entry);
                return entry;
            }
            else
            {
                reccuringEntryTable.Add(entry, entry);
            }
        }

        Debug.Log("All entries in the array are unique");
        return default;
    }

    #endregion
}
