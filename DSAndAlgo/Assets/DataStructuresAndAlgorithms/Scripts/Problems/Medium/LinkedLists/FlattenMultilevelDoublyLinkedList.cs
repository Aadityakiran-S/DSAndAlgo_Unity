using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FlattenMultilevelDoublyLinkedList : MonoBehaviour
{
    #region Question
    //Link to question: https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/ 
    //You are given a doubly linked list, which contains nodes
    //that have a next pointer, a previous pointer, and an additional child pointer.
    //This child pointer may or may not point to a separate doubly linked list, also containing these special nodes.
    //These child lists may have one or more children of their own, and so on, to produce a multilevel data structure
    //as shown in the example below.

    //Given the head of the first level of the list, flatten the list so that all the nodes appear in a single-level,
    //doubly linked list.Let curr be a node with a child list.
    //The nodes in the child list should appear after curr and before curr.next in the flattened list.

    //Return the head of the flattened list. The nodes in the list must have all of their child pointers set to null.

    //Example 1
    //Input: head = [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
    //Output: [1,2,3,7,8,11,12,9,10,4,5,6]
    //Explanation: The multilevel linked list in the input is shown.
    //After flattening the multilevel linked list it becomes:

    //Example 2: 
    //Input: head = [1,2,null,3]
    //Output: [1,3,2]
    //Explanation: The multilevel linked list in the input is shown.
    //After flattening the multilevel linked list it becomes:

    //Example 3:
    //Input: head = []
    //Output: []
    //Explanation: There could be empty list in the input.

    //Constraints:
    //The number of Nodes will not exceed 1000.
    //1 <= Node.val <= 105

    //The serialization of each level is as follows:

    //[1,2,3,4,5,6,null]
    //	[7,8,9,10,null]
    //	[11,12,null]
    //	To serialize all levels together, we will add nulls in each level to signify no node connects to the upper node of the previous
    //	level. The serialization becomes:

    //[1,    2,    3, 4, 5, 6, null]
    //             |
    //[null, null, 7,    8, 9, 10, null]
    //                   |
    //[            null, 11, 12, null]
    //	Merging the serialization of each level and removing trailing nulls we obtain:
    //[1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
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

    private Node Flatten(Node head) //S:1, T:2n
    {
        //No need to flatten if there's nothing given in the first place. 
        if (head == null) return head;

        Node currentNode = head;

        //Move into or to the right. If either node has something below it or to it's right, move ahead
        while (currentNode.next != null || currentNode.child != null)
        {
            if (currentNode.child != null) //Encountered a child? => Go to end and merge up
            {
                Node leftNode = currentNode; currentNode = currentNode.child; //Moving to child branch for end traversal
                Node rightNode = leftNode.next; leftNode.child = null; //Disconnecting child
                currentNode.prev = leftNode; leftNode.next = currentNode; //Setting pointers of left node

                //Traversing to the end of the child branch
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //Reached end of child list
                currentNode.next = rightNode;
                if (rightNode != null) rightNode.prev = currentNode; //Merging tail of child to parent if next node is not null
                currentNode = leftNode; //Resetting pointer to continue iteration
            }
            else //No child, then iterate no problem.
            {
                currentNode = currentNode.next;
            }
        }

        return head;
    }

    #endregion
}

[System.Serializable]
public class MultilevelDoublyLinkedList
{
    public Node head;

    private Node _tail;

    public MultilevelDoublyLinkedList(int value, Node left = null, Node right = null, Node child = null)
    {
        head = new Node(value, left, right, child);
        _tail = head;
    }

    public void Append(int value, Node child = null)
    {
        Node newTail = new Node(value, _tail, null, child);
        _tail.next = newTail;
    }
}


// Definition for a Node.
[System.Serializable]
public class Node
{
    public int val;
    public Node prev;
    public Node next;
    public Node child;

    public Node(int value, Node previous, Node nextNode, Node child)
    {
        this.val = value;
        this.prev = previous;
        this.next = nextNode;
        this.child = child;
    }
}
