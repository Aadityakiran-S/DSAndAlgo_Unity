using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//USE THE SAME LINKED LIST IMPLEMENTATION IN THE REVERSAL QUESTION
public class ReverseLinkedListBetweenTwoEntries : MonoBehaviour
{
    #region Question
    //Given the head of a singly linked list and two integers left and right where left <= right,
    //reverse the nodes of the list from position left to position right,
    //and return the reversed list.

    //Example 1:
    //Input: head = [10,20,30,40,50], left = 2, right = 4
    //Output: [10,40,30,20,50]

    //Example 2:
    //Input: head = [5], left = 1, right = 1
    //Output: [5]


    //Constraints:
    //The number of nodes in the list is n.
    //1 <= n <= 500
    //-500 <= Node.val <= 500
    //1 <= left <= right <= n
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

    private ListNode ReverseBetween(ListNode head, int left, int right) //T: n, S: n
    {
        if (left == right) //If left and right are same, nothing is reversed, no need to do any calculations
        {
            return head;
        }

        int i = 1;
        ListNode currentNode = head;
        ListNode leftNode;
        Stack<int> stack = new Stack<int>();

        while (i < left) //Reaching left pointer
        {
            currentNode = currentNode.next;
            i++;
        }

        stack.Push(currentNode.val); leftNode = currentNode;

        while (i < right) //Storing all values till right node
        {
            currentNode = currentNode.next;
            stack.Push(currentNode.val);
            i++;
        }

        i = left; currentNode = leftNode;

        while (i <= right) //Going back to left pointer and swapping all values
        {
            currentNode.val = stack.Pop();
            currentNode = currentNode.next;
            i++;
        }

        return head;
    }

    private ListNode ReverseBetween_Optimized(ListNode head, int left, int right)
    {
        if (left == right) //If left and right are same, nothing is reversed, no need to do any calculations
        {
            return head;
        }

        ListNode currentNode = head; ListNode beforeLNode = null, afterRNode; int i = 1;

        while (i < left) //Traversing upto left node
        {
            beforeLNode = currentNode; //Setting node just before left node
            currentNode = currentNode.next; //Current node after loop should be leftNode
            i++; //After loop i should be left
        }

        afterRNode = currentNode;
        i = left; //Just restting for readability

        while (i <= right)
        {
            afterRNode = afterRNode.next; //Finding node just after right node
            i++;
        }

        //Resetting pointer back to left node for reversal between left and right
        if (left == 1) //To account for when left is beginning of the list
            currentNode = head;
        else
            currentNode = beforeLNode.next;
        i = left;

        ListNode previousNode = currentNode, nextNode, newSubTailNode = null, newSubHeadNode = null;

        //Reversing linked list between left and right
        while (i <= right)
        {
            if (i == left)
            {
                newSubTailNode = currentNode;

                nextNode = currentNode.next;
                currentNode.next = null;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            else if (i > left && i < right)
            {
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            else //if(i == right)
            {
                newSubHeadNode = currentNode;

                currentNode.next = previousNode;
            }

            i++;
        }

        //Connecting links by pointing before and after reversal segment
        if (beforeLNode != null) //If before left is null, left is the head node
            beforeLNode.next = newSubHeadNode;
        else //So we need to change the head node to the rightNode
            head = newSubHeadNode;

        newSubTailNode.next = afterRNode;

        return head;
    }

    #endregion
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}