using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReorderLinkedList : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/reorder-list/description/

    #endregion

    #region 3 Step method

    public void ReorderList_3Step(ListNode head)
    {
        ListNode mid = FindMid(head);
        ListNode end = FindEnd(head);
        ListNode start = head;

        ReverseConnections(mid);

        while (start != end)
        {
            ListNode start2 = start.next; ListNode end2 = end.next;
            start.next = end; end.next = start2;
            start = (start2 != null) ? start2 : start; end = end2;
        }
    }

    ListNode FindMid(ListNode head)
    {
        ListNode fast = head; ListNode slow = null;
        while (fast != null)
        {
            if (fast.next != null)
            {
                fast = fast.next.next;
            }
            else
            {
                fast = null;
            }

            if (slow == null)
            {
                slow = head;
            }
            else
            {
                slow = slow.next;
            }
        }
        return slow;
    }

    ListNode FindEnd(ListNode head)
    {
        ListNode end = null; ListNode curr = head;
        while (curr != null)
        {
            end = curr; curr = curr.next;
        }
        return end;
    }

    void ReverseConnections(ListNode mid)
    {
        ListNode start = mid; ListNode curr = mid; ListNode next = mid.next;
        while (next != null)
        {
            var temp = next.next;
            next.next = curr; curr = next; next = temp;
        }
        start.next = null;
    }

    #endregion

    #region Using Stack

    public void ReorderList_UsingStack(ListNode head)
    {
        Stack<ListNode> stack = new Stack<ListNode>(); HashSet<ListNode> set = new HashSet<ListNode>();
        ListNode start = head; ListNode end = null;

        //Pushing all values of the List into the stack
        var curr = head;
        while (curr != null)
        {
            stack.Push(curr);
            curr = curr.next;
        }

        //Exit condition for even numbered lists
        while (!set.Contains(stack.Peek()))
        {
            //Exit condition for odd numbered lists
            if (stack.Peek() == start)
            {
                break;
            }
            else
            {
                end = stack.Pop();
            }
            set.Add(start);
            //Logic to do the reordering
            var temp = start.next; start.next = end;
            end.next = temp; start = temp;
        }
        start.next = null;
    }

    #endregion
}