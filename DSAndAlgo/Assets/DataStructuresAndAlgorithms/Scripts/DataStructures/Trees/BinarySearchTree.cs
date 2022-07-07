using System;
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

                currentNode = new BSTNode(0, -1, null); //Simply for DEBUG PURPOSE
            }
            else
            {
                if (currentNode.Value == value) //Found value
                {
                    isFound = true; toStop = true;

                    //Just something to let me know if it's on the left or right. To see if my tree came out right
                    if (currentNode.root == null)    //Root doesn't have a root
                    {
                        lOrR = LeftOrRight.Center;  //Neither left or right
                    }
                    else
                    {
                        if (currentNode.root.left == currentNode)
                            lOrR = LeftOrRight.Left;
                        else
                            lOrR = LeftOrRight.Right;
                    }
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

        IsFoundAtDepth toReturn = new IsFoundAtDepth    //Making something to show position of node DEBUG PURPOSE o/w could have returned just a bool
        {
            nodeToReturn = currentNode,
            isFound = isFound,
            depth = currentNode.depth,
            leftOrRight = lOrR
        };

        return toReturn;
    }

    //TOFIX: Not working when removing single child. Some referencing problem it seems
    public IsFoundAtDepth Remove(int value)
    {
        IsFoundAtDepth foundValue = Lookup(value);
        if (foundValue.nodeToReturn.depth == -1) //Not found
        {
            UnityEngine.Debug.LogWarning("You can't delete what you don't already have");
            return default;
        }

        BSTNode foundNode = foundValue.nodeToReturn;

        //Found has no children? => Either a root with nothing else or a leaf
        if (foundNode.left == null && foundNode.right == null)
        {
            if (foundNode.root == null)  //If is the root itself
            {
                _root = null;
                UnityEngine.Debug.Log("You have delted the root itself");
            }
            else //If is merely a leaf => Delete said node
            {
                foundNode.root.DecoupleChild(foundNode);
            }
        }
        else if (foundNode.left != null || foundNode.right != null)   //Found has at least one child
        {
            BSTNode nodeToReplace;

            //Exactly 2 children => Replace with min value in right sub tree or max value in left
            if (foundNode.left != null && foundNode.right != null)
            {
                nodeToReplace = FindMinNodeInRightSubTree(foundNode);
            }
            else //Exactly one child => Delete parent, replace with child
            {
                if (foundNode.left == null)
                {
                    nodeToReplace = foundNode.right;
                }
                else
                {
                    nodeToReplace = foundNode.left;
                }
            }

            ///How to replace really? (Also, replace the variable in case you're removing root)
            /// Replacement occurs when all refs to the objct are gone
            /// => the root of it has to loose ref to it
            /// and the children from it have to ref new parent
            /// 

            if (foundNode == Root) //If found node is root, then new root is nodeToReplace
            {
                Root = nodeToReplace;
            }

            var rootOfFoundNode = foundNode.root;
            if (rootOfFoundNode != null) //That is, found node is not root
            {
                ///What do we have to do?
                /// Replace the foundNode in the root with the temp node
                /// Replace temp node's root with root node


            }
            else //Found node is root itself
            {
                ///What to do in this case? 
                /// 
            }
        }

        return foundValue;
    }

    public int[] PopulateBSFArray_Recursive()
    {
        Queue<BSTNode> queue = new Queue<BSTNode>(); queue.Enqueue(this.Root);
        List<int> list = new List<int>();

        return Return_BFSValuesInTree_Recursive(queue, list);
    }

    public int[] PopulateBSFArray_Iterative()
    {
        return Return_BFSValuesInTree_Iterative(this.Root);
    }

    public int[] Populate_DFSValues_InOrder()
    {
        List<int> list = new List<int>();
        return Traverse_InOrder(this.Root, list);
    }   

    public int[] Populate_DFSValues_PreOrder()
    {
        List<int> list = new List<int>();
        return Traverse_PreOrder(this.Root, list);
    }

    public int[] Populate_DFSValues_PostOrder()
    {
        List<int> list = new List<int>();
        return Traverse_PostOrder(this.Root, list);
    }

    //DOLATER: Create function to find the next largest element in the tree.
    //DOLATER: Create function to find the next smallest element in the tree.
    //DOLATER: Make a method to convert this tree to an ordered linked list.

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

    private BSTNode FindMinNodeInRightSubTree(BSTNode nodeToReplace)
    {
        BSTNode nodeToReturn = null; bool toStop = false;
        while (!toStop)
        {
            if (nodeToReplace.left == null) //If there's no left for this node, then it iteslf if min
            {
                toStop = true;
                nodeToReturn = nodeToReplace;
            }
            else //Otherwise, simply keep moving left
            {
                nodeToReplace = nodeToReplace.left;
            }
        }

        return nodeToReturn;
    }

    private int[] Return_BFSValuesInTree_Iterative(BSTNode node)
    {
        List<int> listToReturn = new List<int>(); Queue<BSTNode> tempQueue = new Queue<BSTNode>();
        tempQueue.Enqueue(node);

        while (tempQueue.Count > 0)
        {
            BSTNode currentNode = tempQueue.Dequeue();
            listToReturn.Add(currentNode.Value);

            if (currentNode.left != null)
            {
                tempQueue.Enqueue(currentNode.left);
            }
            if (currentNode.right != null)
            {
                tempQueue.Enqueue(currentNode.right);
            }
        }

        return listToReturn.ToArray();
    }

    private int[] Return_BFSValuesInTree_Recursive(Queue<BSTNode> queue, List<int> list)
    {
        //Base case: When there are no more elements in the queue
        if (queue.Count == 0)
        {
            return list.ToArray();
        }

        BSTNode currentNode = queue.Dequeue();
        list.Add(currentNode.Value);

        if (currentNode.left != null)
        {
            queue.Enqueue(currentNode.left);
        }
        if (currentNode.right != null)
        {
            queue.Enqueue(currentNode.right);
        }

        return Return_BFSValuesInTree_Recursive(queue, list);
    }

    //Returns all elements in the tree in order
    private int[] Traverse_InOrder(BSTNode node, List<int> list)
    {
        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }

        list.Add(node.Value);

        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        return list.ToArray();
    }

    //Returns elements as they are if added again to the tree, would form the same structure
    private int[] Traverse_PreOrder(BSTNode node, List<int> list)
    {
        list.Add(node.Value);

        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }
        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        return list.ToArray();
    }

    private int[] Traverse_PostOrder(BSTNode node, List<int> list)
    {
        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }
        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        list.Add(node.Value);

        return list.ToArray();
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

    public void DecoupleChild(BSTNode childNode)
    {
        if (childNode == this.left)
        {
            this.left = null;
        }
        else if (childNode == this.right)
        {
            this.right = null;
        }
        else //Neither right nor left
        {
            UnityEngine.Debug.LogError("You are trying to decouple a child that is not a child of a node. What the hell bro?");
            return;
        }
    }

    public void ReplaceChild(BSTNode childToReplace)
    {

    }
}

[System.Serializable]
public struct IsFoundAtDepth
{
    public BSTNode nodeToReturn;
    public bool isFound;
    public int depth;
    public LeftOrRight leftOrRight;
}

[System.Serializable]
public enum LeftOrRight
{
    Right, Left, Center
}
