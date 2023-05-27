
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RemoveElementFromLinkedList : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/remove-linked-list-elements/description/

    #endregion

    #region Method 1

    public ListNode RemoveElements_1(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;
        }
        if (head == null)
        {
            goto end;
        }
        ListNode curr = head; ListNode prev = null;
        while (curr != null)
        {
            if (curr.val == val)
            {
                curr = curr.next;
                prev.next = curr;
            }
            else
            {
                prev = curr;
                curr = curr.next;
            }
        }
        end:
        return head;
    }

    #endregion

    #region Method 2

    public ListNode RemoveElements_2(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;
        }
        if (head == null)
        {
            goto end;
        }
        ListNode curr = head; ListNode prev = null;
        Recurse(prev, curr, val);

        end:
        return head;
    }

    void Recurse(ListNode prev, ListNode curr, int val)
    {
        if (curr == null)
        {
            return;
        }

        if (curr.val == val)
        {
            curr = curr.next;
            prev.next = curr;
        }
        else
        {
            prev = curr;
            curr = curr.next;
        }
        Recurse(prev, curr, val);
    }

    #endregion

    #region Method 3

    public ListNode RemoveElements_3(ListNode head, int val)
    {
        if (head == null)
        {
            return head;
        }
        head.next = RemoveElements_3(head.next, val);
        return head.val == val ? head.next : head;
    }

    #endregion

    #region Method 4

    public ListNode RemoveElements_4(ListNode head, int val)
    {
        ListNode temp = new ListNode(0); temp.next = head;
        ListNode prev = temp; ListNode curr = head;
        while (curr != null)
        {
            if (curr.val == val)
            {
                prev.next = curr.next;
            }
            else
            {
                prev = curr;
            }
            curr = curr.next;
        }
        return temp.next;
    }

    #endregion
}