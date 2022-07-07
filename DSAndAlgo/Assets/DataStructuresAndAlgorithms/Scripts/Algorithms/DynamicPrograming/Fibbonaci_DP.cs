using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Fibbonaci_DP : MonoBehaviour
{
    #region References
    [SerializeField] int _indexToCalculate;

    private Hashtable _memoizationTable;
    #endregion

    #region UnityLifecycle

    private void Awake()
    {
        _memoizationTable = new Hashtable();
    }

    private void Start()
    {
        Debug.Log("Fibbonaci of " + _indexToCalculate + " is " + CalculateFibbonaci_DP(_indexToCalculate));
    }

    #endregion

    #region Methods

    private int CalculateFibbonaci_DP(int fibIndex)
    {
        if (_memoizationTable.Contains(fibIndex))
        {
            return (int)_memoizationTable[fibIndex];
        }

        if(fibIndex == 0)
        {
            return 0;
        }

        if (fibIndex == 1)
        {
            return 1;
        }

        int result = CalculateFibbonaci_DP(fibIndex - 1) + CalculateFibbonaci_DP(fibIndex - 2);
        _memoizationTable.Add(fibIndex, result);

        return result;
    }


    #endregion
}