using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree
{
    #region References and Constructor

    private BSTNode _root;
    public BSTNode Root { get => _root; private set => _root = value; }

    private int _numberOfLevels;
    public int NumberOfLevels { get => _numberOfLevels; private set => _numberOfLevels = value; }

    private Hashtable _entriesTable;

    const int SPACECOUNT = 5;

    public BinarySearchTree()
    {
        this.Root = null;
        _entriesTable = new Hashtable();
    }

    #endregion

    #region Public Methods

    public void Insert(int value)
    {
        //Error check to account for duplicates
        if (_entriesTable.Contains(value))
        {
            UnityEngine.Debug.LogWarning(value + " is a duplicate entry. That's not allowed");
            return;
        }
        else
        {
            _entriesTable.Add(value, value);
        }


        bool toStop = false; BSTNode currentNode = Root; int depth = 0;

        if (Root == null)    //We haven't set the root yet. Which means we removed everything from this tree
        {
            Root = new BSTNode(value, 0, null);
            return;
        }

        while (!toStop)
        {
            if (currentNode != null)
            {
                depth++;    //Incrementing before passing onto the new level
                currentNode = CheckNextLevel(currentNode, value, depth);
            }
            else
                toStop = true;
        }

        _numberOfLevels = depth;
    }

    public IsFoundAtDepth Lookup(int value)
    {
        BSTNode currentNode = Root; bool toStop = false, isFound = false; LeftOrRight lOrR = LeftOrRight.Center;

        while (!toStop)
        {
            if (currentNode == null)    //Value not found. Reached end
            {
                isFound = false; toStop = true;
            }
            else
            {
                if (currentNode.Value == value) //Found value
                {
                    isFound = true; toStop = true;

                    //Just something to let me know if it's on the left or right. To see if my tree came out right
                    if (currentNode.root.left == currentNode)
                        lOrR = LeftOrRight.Left;
                    else
                        lOrR = LeftOrRight.Right;

                }
                else if (currentNode.Value < value)
                {
                    currentNode = currentNode.right;
                }
                else     //condition when currentNode has greater value than our value
                {
                    currentNode = currentNode.left;
                }
            }
        }

        if (currentNode == null) //Simply for debug purposes
        {
            currentNode = new BSTNode(0, -1, null);
        }

        IsFoundAtDepth toReturn = new IsFoundAtDepth
        {
            isFound = isFound,
            depth = currentNode.depth,
            rightOrLeft = lOrR
        };

        return toReturn;
    }

    public void PrintTree()
    {
        Print2DUtil(_root, 0);
    }

    #endregion

    #region Private Functions

    private BSTNode CheckNextLevel(BSTNode node, int value, int depth)
    {
        if (node.Value > value) //Condition where currentNode value is greater => Move to left
        {
            if (node.left == null)  //No value at left so we can put it there
            {
                node.left = new BSTNode(value, depth, node);
                return null;
            }
            else
                return node.left;
        }
        else //Condition where currentNode value is less => Move to right
        {
            if (node.right == null) //No value at right so we can put it there
            {
                node.right = new BSTNode(value, depth, node);
                return null;
            }
            else
                return node.right;
        }
    }

    private void Print2DUtil(BSTNode root, int space)
    {
        // Nothing in tree at all => Nothing to print
        if (root == null)
        {
            UnityEngine.Debug.LogWarning("Your tree is empty");
            return;
        }

        // Increase distance between levels  
        space += SPACECOUNT;

        // Process right child first  
        Print2DUtil(root.right, space);

        // Print current node after space  
        // count  
        UnityEngine.Debug.Log("\n");
        for (int i = SPACECOUNT; i < space; i++)
        {
            UnityEngine.Debug.Log(" ");
        }
        UnityEngine.Debug.Log(root.Value + "\n");

        // Process left child  
        Print2DUtil(root.left, space);
    }

    #endregion
}

[System.Serializable]
public class BSTNode
{
    //Alll these should be mutable. On reorganization the should change
    public BSTNode root;
    public BSTNode left;
    public BSTNode right;

    public int depth;   //Depth can be changed when the tree is reordere

    private int _value; //Value cannot be changed once a tree is made. Since if changed it will mess everything up
    public int Value { get => _value; private set => this._value = value; }

    public BSTNode(int value, int depth, BSTNode root)
    {
        this._value = value;
        this.depth = depth;
        this.root = root;

        this.left = null;
        this.right = null;
    }
}

[System.Serializable]
public struct IsFoundAtDepth
{
    public bool isFound;
    public int depth;
    public LeftOrRight rightOrLeft;
}

[System.Serializable]
public enum LeftOrRight
{
    Right, Left, Center
}
