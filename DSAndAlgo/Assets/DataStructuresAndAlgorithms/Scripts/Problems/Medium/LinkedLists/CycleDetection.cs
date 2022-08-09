using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CycleDetection : MonoBehaviour
{
    #region Question
    //Link to question: https://leetcode.com/problems/linked-list-cycle-ii/

    //Given the head of a linked list, return the node where the cycle begins.If there is no cycle, return null.
    //There is a cycle in a linked list if there is some node in the list that can be reached again by continuously
    //following the next pointer.Internally, pos is used to denote the index of the node that tail's
    //next pointer is connected to (0-indexed). It is -1 if there is no cycle. Note that pos is not passed as a parameter.

    //Do not modify the linked list.

    //Example 1:
    //Input: head = [3,2,0,-4], pos = 1
    //Output: tail connects to node index 1
    //Explanation: There is a cycle in the linked list, where tail connects to the second node.

    //Example 2:
    //Input: head = [1,2], pos = 0
    //Output: tail connects to node index 0
    //Explanation: There is a cycle in the linked list, where tail connects to the first node.

    //Example 3:
    //Input: head = [1], pos = -1
    //Output: no cycle
    //Explanation: There is no cycle in the linked list.

    //Constraints:
    //The number of the nodes in the list is in the range[0, 104].
    //-105 <= Node.val <= 105
    //pos is -1 or a valid index in the linked-list.

    //Follow up: Can you solve it using O(1)(i.e.constant) memory ?
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

    //Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.
    private ListNode DetectCycle(ListNode head) //S:n , T:n
    {
        if (head == null) return null;

        Dictionary<ListNode, ListNode> entryDict = new Dictionary<ListNode, ListNode>();
        ListNode currentNode = head;

        while (currentNode.next != null)
        {
            if (entryDict.ContainsKey(currentNode))
            {
                return currentNode;
            }
            else
            {
                entryDict.Add(currentNode, currentNode); currentNode = currentNode.next;
            }
        }

        return null;
    }

    private ListNode DetectCycle_FloydTortoiseAndHare(ListNode head)//T:n, S:1
    {
        //Error check
        if (head == null) return null;

        ListNode tortoise = head; ListNode hare = IncrementHare(head);

        while(hare != null)
        {
            if(tortoise != hare) //Tortise and hare are still in the race
            {
                tortoise = tortoise.next; hare = IncrementHare(hare);
            }
            else //Tortise and hare have met
            {
                ListNode left = head; ListNode right = tortoise;

                while(left != right)
                {
                    left = left.next; right = right.next;
                }

                return left;
            }
        }

        return null;
    }

    #endregion

    #region Helper functions

    ListNode IncrementHare(ListNode hare)
    {
        if (hare == null) return null;
        else if (hare.next == null) return null;
        else return hare.next.next;
    }

    #endregion
}
