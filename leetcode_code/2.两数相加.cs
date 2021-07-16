/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode ret = null;
        ListNode last = null;
        ListNode p1 = l1;
        ListNode p2 = l2;

        int tmp = 0;
        while (p1!=null || p2!=null)
        {
            int sum = (p1==null?0:p1.val) + (p2 == null ? 0 : p2.val) + tmp;
            tmp = sum / 10;
            ListNode newnode = new ListNode(sum%10);
            if (last != null)
                last.next = newnode;
            else
            {
                ret = newnode;
            }

            last = newnode;

            if (p1!=null)
                p1 = p1.next;
            if (p2 != null)
                p2 = p2.next;
        }
        // 
        if (tmp>0)
        {
            ListNode newnode = new ListNode(tmp);
            last.next = newnode;
        }
        return ret;
    }

    public ListNode GenListNode(int[] nums)
    {
        ListNode first = new ListNode(nums[0]);
        ListNode last = first;
        for (int i=1; i<nums.Length; i++)
        {
            ListNode node = new ListNode(nums[i]);
            last.next = node;
            last = node;
        }
        return first;
    }
}
// @lc code=end

