using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FindFirstIndexOfOccurance : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/

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

    public int StrStr(string h, string n)
    {
        if (n.Length > h.Length)
        {
            return -1;
        }
        if (n.Length == h.Length)
        {
            if (n == h)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        for (int i = 0; i < h.Length; i++)
        {
            if (h[i] != n[0])
            {
                continue;
            }

            //If not enough chars left to iterate through => negative return
            if (h.Length - i < n.Length)
            {
                return -1;
            }

            int temp = i;
            for (int j = 0; j < n.Length; j++)
            {
                if (n[j] == h[temp])
                {
                    temp++;
                    if (j == n.Length - 1)
                    {
                        return i;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        return -1;
    }

    #endregion

    #region Helper Methods	



    #endregion
}