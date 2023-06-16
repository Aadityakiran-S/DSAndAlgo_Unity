using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SnapShotArray : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/snapshot-array/description/

    #endregion

    #region Methods

    public class SnapshotArray
    {

        //Rather than storing one array per snapshot, 
        // we store a dict containing values for each snapshot,
        // indices are stored as the index of the parent array
        private readonly Dictionary<int, int>[] _array;
        private int _snapshotId;

        public SnapshotArray(int length)
        {
            _array = new Dictionary<int, int>[length];
            for (int i = 0; i < length; i++)
            {
                _array[i] = new Dictionary<int, int>(); //Initializing a new dict for each index
                _array[i].Add(0, 0); //current snap is 0, so initializing 0 to it on all indices
            }
            _snapshotId = 0;
        }

        public void Set(int index, int val)
        {
            //For the current snapID, storing the val in the index
            _array[index][_snapshotId] = val;
        }

        public int Snap()
        {
            //Increments snapshotId after giving the current outside
            //Doesn't matter how many times snapshots are taken, values are already stored
            //Further values will be stored later on using new snapID
            return _snapshotId++;
        }

        public int Get(int index, int snapId)
        {
            var dictionary = _array[index];

            //If snapId is not in the dictionary we should go back to previous snapshot
            while (!dictionary.ContainsKey(snapId))
            {
                snapId--;
            }

            return dictionary[snapId];
        }
    }


    #endregion
}