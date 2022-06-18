using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestForCompliment_GoogleInterviewDemo : MonoBehaviour
{
    #region References

    [SerializeField] private int[] _inputArray;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        //Call either function here
    }

    #endregion

    #region Private Functions

    public bool CheckIfAPairOfEntriesAddsUpToGivenSum_BRUTE(int[] array, int sum)
    {
        //Error checks
        if(array.Length < 2)
        {
            Debug.Log("Array either has no elemnts or just one. \n" +
                "in either case, compliment is out of the question");
            return false;
        }


        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] + array[j] == sum)
                {
                    Debug.Log("Matching pair found: " + array[i] + " and " + array[j]);
                    return true;
                }
            }
        }

        Debug.Log("No mathcing pairs found");
        return false;
    }

    public bool CheckIfAPairOfEntriesAddsUpToGivenSum_EFFICIENT(int[] array, int sum)
    {
        //Error checks
        if (array.Length < 2)
        {
            Debug.Log("Array either has no elemnts or just one. \n" +
                "in either case, compliment is out of the question");
            return false;
        }

        //Can be made more efficient with HashTables as discussed in the interview but
        //We've not reached there yet. So we can just do this for now.
        List<int> complementList = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (complementList.Contains(array[i]))
            {
                Debug.Log("Matching pair found: " + array[i] + " and " + (sum - array[i]));
                return true;
            }
            else
                complementList.Add(sum - array[i]);
        }

        Debug.Log("No mathcing pairs found");
        return false;
    }

    #endregion
}
