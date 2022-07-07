using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] int _entryToLookUp;
    [SerializeField] int[] _valuesToEnter;

    [Space(2.5f)]
    [Header("Output values")] 
    [SerializeField] int[] _bfsValues;
    [SerializeField] int[] _dfsValues;

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

        _bfsValues = new int[_valuesToEnter.Length];

        //I've added the entries in an array in the inspector but you can add manually as well
        //_tree.Insert(9);  
        //_tree.Insert(4);
        //_tree.Insert(6);
        //_tree.Insert(20);
        //_tree.Insert(170);
        //_tree.Insert(15);
        //_tree.Insert(1);

        //_tree.Insert(14);
        //_tree.Insert(16);
        //_tree.Insert(0);
        //_tree.Insert(8);
    }

    //Testing for Insert here, test for remove in Unit Tests
    private void Start()
    {
        IsFoundAtDepth foundAtDepth = _tree.Lookup(_entryToLookUp);
        string rootValue;
        if (foundAtDepth.nodeToReturn.root == null)
        {
            rootValue = "Nothing. Either you didn't find me or I'm the root";
        }
        else
        {
            rootValue = foundAtDepth.nodeToReturn.root.Value.ToString();
        }

        Debug.Log("Entry: " + _entryToLookUp + " is found? " + foundAtDepth.isFound + " at depth " + foundAtDepth.depth +
            " on the " + foundAtDepth.leftOrRight + " of " + rootValue);

        Debug.Log("To the right of entry is " + foundAtDepth.nodeToReturn.right);
        Debug.Log("To the left of entry is " + foundAtDepth.nodeToReturn.left);

        _bfsValues = _tree.PopulateBSFArray_Recursive();
    }

    #endregion
}
