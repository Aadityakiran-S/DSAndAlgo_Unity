using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GuessingGame : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/guess-number-higher-or-lower/description/

    #endregion

    #region Methods		

    public int GuessNumber(int n)
    {
        int l = 1; int r = n;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            int res = guess(m);
            if (res == 0)
            {
                return m;
            }
            else if (res == 1)
            {
                l = m + 1;
            }
            else if (res == -1)
            {
                r = m;
            }
        }
        return l;
    }


    #endregion

    private int guess(int m)
    {
        return 0;
    }
}