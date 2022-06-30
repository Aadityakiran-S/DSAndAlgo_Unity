using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseLinkedList : MonoBehaviour
{
    #region References

    [SerializeField] LinkedList<int> _listToReverse;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _listToReverse = new LinkedList<int>();

        for (int i = 0; i < 11; i++)
        {
            _listToReverse.AddLast(i);
        }
    }


    private void Start()
    {
        foreach (var item in _listToReverse)
        {
            Debug.Log("input list entry " + item);
        }

        _listToReverse = ReverseGivenLinkedList(_listToReverse);

        Debug.Log("########################");

        foreach (var item in _listToReverse)
        {
            Debug.Log("ouput list entry " + item);
        }
    }

    #endregion

    #region Methods

    public LinkedList<T> ReverseGivenLinkedList<T>(LinkedList<T> inputList)
    {
        LinkedList<T> outputList = new LinkedList<T>();

        foreach (var item in inputList)
        {
            outputList.AddFirst(item);
        }

        return outputList;
    }


    #endregion
}
