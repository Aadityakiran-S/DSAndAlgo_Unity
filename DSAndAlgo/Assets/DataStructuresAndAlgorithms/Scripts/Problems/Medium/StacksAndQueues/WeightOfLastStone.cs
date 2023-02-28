using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WeightOfLastStone : MonoBehaviour
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

    #region Methods	

    #region Binary Search Solution
    //Solution using Binary Search
    public int LastStoneWeight1(int[] stones)
    {
        //Sorting array in ascending order to do binary search later on 
        // T: O(nlogn)
        Array.Sort(stones);
        List<int> list = new List<int>();
        List<int> stoneList = list; //Converting to list since we need to do Binary Search later
        foreach (var stone in stones)
        {
            stoneList.Add(stone);
        }

        //Continue iteration till all but one stone is left at most
        //T: O(nlogn) since we're doing BS for every element in list
        while (stoneList.Count > 1)
        {
            //Smashing together last 2 stones
            int last = stoneList[stoneList.Count - 1];
            stoneList.RemoveAt(stoneList.Count - 1);
            int secondLast = stoneList[stoneList.Count - 1];
            stoneList.RemoveAt(stoneList.Count - 1);

            //Calculating left weight of stone after destroying 
            int diff = Math.Abs(last - secondLast);
            if (diff > 0)
            {
                //Binary search on stones to find where to put new stone
                int pos = stoneList.BinarySearch(diff); //T: O(logn)
                if (pos < 0)
                {
                    pos = ~pos;
                }

                stoneList.Insert(pos, diff); //T: O(logn)
            }
        }

        //Return 0 if none remain or weight of last stone remaining
        return (stoneList.Count > 0) ? stoneList[0] : 0;
    }
    #endregion

    #region Priority Queue Solution
    //private PriorityQueue<int, int> pq;

    //// T: O(NLogN)
    //public int LastStoneWeight(int[] stones)
    //{
    //    pq = new(new MaxHeapComparer());

    //    foreach (var stone in stones)
    //    {
    //        // T: Heapify is O(N) for every enqueued item
    //        pq.Enqueue(stone, stone);
    //    }

    //    // T: O(NLogN), to get max value its O(LogN) and we perform this for N items => O(NLogN)
    //    while (pq.Count > 1)
    //    {
    //        var y = pq.Dequeue();
    //        var x = pq.Dequeue();

    //        if (x != y)
    //        {
    //            var diff = Math.Abs(y - x);
    //            pq.Enqueue(diff, diff);
    //        }
    //    }

    //    return pq.Count == 0 ? 0 : pq.Dequeue();
    //}

    ////Default PQ in C# is a min heap. This converts it into a max Heap. 
    ////When passing this on initialization, this overrides the default comparator.
    ////If you want min heap, either don't put this or turn COMPARE line to x - y
    //public class MaxHeapComparer : IComparer<int>
    //{
    //    public int Compare(int x, int y)
    //    {
    //        return y - x; /*COMPARE*/
    //    }
    //}
    #endregion

    #endregion

    #region Helper Methods	



    #endregion
}