using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] int _entryToLookUp;
    [SerializeField] int[] _valuesToEnter;

    private BinarySearchTree _tree;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _tree = new BinarySearchTree();

        foreach (var entry in _valuesToEnter)
        {
            _tree.Insert(entry);
        }

        //I've added the entries in an array in the inspector but you can add manually as well
        //_tree.Insert(9);  
        //_tree.Insert(4);
        //_tree.Insert(6);
        //_tree.Insert(20);
        //_tree.Insert(170);
        //_tree.Insert(15);
        //_tree.Insert(1);
    }

    private void Start()
    {
        //_tree.PrintTree();

        IsFoundAtDepth foundAtDepth = _tree.Lookup(_entryToLookUp);
        Debug.Log("Entry: " + _entryToLookUp + " is found? " + foundAtDepth.isFound + " at depth " + foundAtDepth.depth +
            " on the " + foundAtDepth.rightOrLeft);
    }

    #endregion
}
