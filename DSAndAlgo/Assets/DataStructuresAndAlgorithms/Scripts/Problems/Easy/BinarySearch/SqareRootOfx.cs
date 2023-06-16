using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SqareRootOfx : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/sqrtx/description/

    #endregion

    #region Methods

    public int MySqrt_4(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }

        //Using closure
        void Recurse(int l, int r, int x, ref int sqrt)
        {
            if (l == r)
            {
                sqrt = (l * l == x) ? l : l - 1;
                return;
            }

            decimal m = l + (r - l) / 2;

            if (m * m == x)
            {
                sqrt = (int)m;
                return;
            }
            else if (m * m > x)
            {
                Recurse(l, (int)m, x, ref sqrt);
            }
            else if (m * m < x)
            {
                Recurse((int)m + 1, r, x, ref sqrt);
            }
        }

        int l = 0; int r = x; int sqrt = 0;
        Recurse(l, r, x, ref sqrt);

        return sqrt;
    }

    public int MySqrt_3(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }
        int l = 0; int r = x; int sqrt = 0;
        Recurse(l, r, x, ref sqrt);

        return sqrt;
    }

    private void Recurse(int l, int r, int x, ref int sqrt)
    {
        if (l == r)
        {
            sqrt = (l * l == x) ? l : l - 1;
            return;
        }

        decimal m = l + (r - l) / 2;

        if (m * m == x)
        {
            sqrt = (int)m;
            return;
        }
        else if (m * m > x)
        {
            Recurse(l, (int)m, x, ref sqrt);
        }
        else if (m * m < x)
        {
            Recurse((int)m + 1, r, x, ref sqrt);
        }
    }

    //Binary search method T: O(log(x))
    public int MySqrt_2(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }
        int l = 0; int r = x;
        while (l < r)
        {
            //Cast to decimal to prevent overflow on taking m*m
            //when x = int.MAX_VALUE since decimal has greater precision
            decimal m = l + (r - l) / 2;

            //Cast back to int when putting indices
            if (m * m == x)
            {
                return (int)m;
            }
            else if (m * m > x)
            {
                r = (int)m;
            }
            else if (m * m < x)
            {
                l = (int)m + 1;
            }
        }
        //At this point both l and r will be at the same value
        return (l * l == x) ? l : l - 1;
    }

    //BRUTE FORCE method T: O(sqrt(x))
    public int MySqrt_1(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            if (i * i == x)
            {
                return i;
            }
            else if (i * i > x)
            {
                return i - 1;
            }
        }
        return 0;
    }

    #endregion
}