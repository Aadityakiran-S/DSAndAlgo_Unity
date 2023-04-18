using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LongPressedWords : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/long-pressed-name/description/

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

    public bool IsLongPressedName(string name, string typed)
    {
        if (name.Length > typed.Length)
        {
            return false;
        }
        else if (name.Length == typed.Length)
        {
            return (name == typed);
        }

        int i = 0; int j = 0;
        while (i < name.Length && j < typed.Length)
        {
            if (name[i] == typed[j])
            {
                i++; j++;
            }
            else
            {
                //Different letter in the beginning itself => not a long press 
                if (j == 0)
                {
                    return false;
                }

                //Previous not the same as current? -> Not long pressed. Mistake
                if (typed[j - 1] != typed[j])
                {
                    return false;
                }

                while (j < typed.Length && typed[j - 1] == typed[j])
                {
                    j++;
                }
            }
        }

        //j only overflowed => cannot be the same since there's stuff left to compare in i
        if (j >= typed.Length && i < name.Length)
        {
            return false;
        }
        //i only overflowed or both together => rest of letters in j should be same as previous one
        else
        {
            while (j < typed.Length)
            {
                if (typed[j - 1] != typed[j])
                {
                    return false;
                }
                j++;
            }
        }

        return true;
    }

    #endregion

    #region Helper Methods	



    #endregion
}