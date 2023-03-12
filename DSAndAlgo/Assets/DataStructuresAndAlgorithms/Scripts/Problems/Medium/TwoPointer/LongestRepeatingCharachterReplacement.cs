using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LongestRepeatingCharachterReplacement : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/longest-repeating-character-replacement/

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

    public int CharacterReplacement(string input, int k)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int i = 0; int j = 0; int maxL = 0; dict.Add(input[j], 1);

        //Two pointer method to find max length of substring
        while (i < input.Length && j < input.Length)
        {

            //Subtracting most frequent element count from substring length 
            //since we're replacing all other elements other than most frequent one to get output
            if ((j - i + 1) - MostFreqElement(dict) <= k)
            {
                maxL = Math.Max(maxL, (j - i + 1));
                j++;

                //Break condition when right has reached end of input
                if (j == input.Length)
                {
                    break;
                }
                else
                {
                    AddToDict(dict, input[j]);
                }

            }
            //If replacable elements are greater than permissible,
            //shift left and remove that from dict
            else
            {
                dict[input[i]]--; i++;
            }
        }

        return maxL;
    }

    #endregion

    #region Helper Methods	

    private int MostFreqElement(Dictionary<char, int> dict)
    {
        int count = 0;
        foreach (var entry in dict)
        {
            count = Math.Max(count, entry.Value);
        }

        return count;
    }

    private void AddToDict(Dictionary<char, int> dict, char key)
    {
        if (dict.ContainsKey(key))
        {
            dict[key]++;
        }
        else
        {
            dict.Add(key, 1);
        }
    }

    #endregion
}