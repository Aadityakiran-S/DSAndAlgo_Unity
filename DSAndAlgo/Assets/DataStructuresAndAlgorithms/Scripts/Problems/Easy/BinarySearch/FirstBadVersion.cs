using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FirstBadVersion : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/first-bad-version/

    #endregion

    #region Methods		

    public int FirstBadVersion_1(int n)
    {
        int l = 1; int r = n;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            bool isBad = IsBadVersion(m);

            if (isBad)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return IsBadVersion(l) ? l : l + 1;
    }

    #endregion

    bool IsBadVersion(int l)
    {
        return false;
    }
}