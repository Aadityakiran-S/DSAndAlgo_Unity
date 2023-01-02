using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PrefixTrie : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/implement-trie-prefix-tree/
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


    #endregion
}

public class Trie
{
    #region References and Constructor
    private Dictionary<char, TrieNode> _startingCharDict;

    public Trie()
    {
        _startingCharDict = new Dictionary<char, TrieNode>();
    }
    #endregion

    #region Public Methods

    public void Insert(string word)
    {
        TrieNode newNode;

        if (!_startingCharDict.ContainsKey(word[0]))
        {
            newNode = new TrieNode(word[0]);
            _startingCharDict.Add(word[0], newNode);
        }
        else
        {
            newNode = _startingCharDict[word[0]];
        }

        RecursiveInsert(word, 0, newNode);
    }

    public bool Search(string word)
    {
        //If starting char itself is not there => Return false
        if (!_startingCharDict.ContainsKey(word[0]))
        {
            return false;
        }

        TrieNode startingNode = _startingCharDict[word[0]];

        return RecursiveSearch(word, 0, startingNode);
    }

    public bool StartsWith(string prefix)
    {
        //If starting char itself is not there => Return false
        if (!_startingCharDict.ContainsKey(prefix[0]))
        {
            return false;
        }

        TrieNode startingNode = _startingCharDict[prefix[0]];

        return RecursivePrefixSearch(prefix, 0, startingNode);
    }

    #endregion

    #region Helper Methods

    private void RecursiveInsert(string word, int index, TrieNode currentNode)
    {
        //If this is last char => Simply add termination flag and exit
        if (index == word.Length - 1)
        {
            if (currentNode.IsAnEndChar == true)
            {
                Console.WriteLine("Word already exists");
                return;
            }
            else
            {
                currentNode.IsAnEndChar = true;
                return;
            }
        }

        //if not last char => Check for child 
        TrieNode nextChild = currentNode.ReturnChild(word[index + 1]);

        //If child DNE, make one and recurse
        if (nextChild == null)
            nextChild = currentNode.AddChild(word[index + 1]);

        RecursiveInsert(word, index + 1, nextChild);
    }

    private bool RecursiveSearch(string word, int index, TrieNode currentNode)
    {
        //If currentNode is null => This char DNE in Trie
        if (currentNode == null)
        {
            return false;
        }

        //If at last char => Check if end flag set
        if (index == word.Length - 1)
        {
            if (currentNode.IsAnEndChar == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //if not last char => Check for child
        TrieNode nextChild = currentNode.ReturnChild(word[index + 1]);
        return RecursiveSearch(word, index + 1, nextChild);
    }

    private bool RecursivePrefixSearch(string prefix, int index, TrieNode currentNode)
    {
        //If currentNode is null => This char DNE in Trie
        if (currentNode == null)
        {
            return false;
        }

        //If at last char => then prefix exists
        if (index == prefix.Length - 1)
        {
            return true;
        }

        //if not last char => Check for child
        TrieNode nextChild = currentNode.ReturnChild(prefix[index + 1]);
        return RecursivePrefixSearch(prefix, index + 1, nextChild);
    }

    #endregion
}

public class TrieNode
{
    #region Referances and Constructor
    private bool _isAnEndChar;
    public bool IsAnEndChar
    {
        get => _isAnEndChar;
        set
        {
            if (value == true)
            {
                _isAnEndChar = value;
            }
            else
            {
                //Debug.Log("This char is an end char, you can't change that");
                Console.Write("This char is an end char, you can't change that");
            }
        }
    }

    private char _value;
    public char Value { get => _value; private set => _value = value; }

    private Dictionary<char, TrieNode> _childrenDict;

    public TrieNode(char value)
    {
        this._value = value;
        this._isAnEndChar = false;
        _childrenDict = new Dictionary<char, TrieNode>();
    }

    #endregion

    #region Methods

    public TrieNode AddChild(char value)
    {
        TrieNode childNode = new TrieNode(value);
        _childrenDict.Add(value, childNode);

        return childNode;
    }

    public TrieNode ReturnChild(char value)
    {
        if (_childrenDict.ContainsKey(value))
        {
            return _childrenDict[value];
        }
        else
        {
            return null;
        }
    }

    #endregion
}