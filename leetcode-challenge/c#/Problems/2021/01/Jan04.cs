namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3592/
  ///    https://leetcode.com/submissions/detail/438363279/?from=explore&item_id=3592
  /// </summary>
  internal class Jan04
  {
    /**
     Definition for singly-linked list.*/
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
     
    public class Solution
    {
      public ListNode MergeTwoLists(ListNode l1, ListNode l2)
      {
        return MergeKLists(new ListNode[] { l1, l2 });
      }

      public ListNode MergeKLists(ListNode[] lists)
      {
        ListNode node = new ListNode(0);
        ListNode currentNode = node;

        int? index = null;

        do
        {
          index = GetMinListIndex(lists);
          if (index == null)
            break;

          var newNode = new ListNode(lists[index.Value].val);
          currentNode.next = newNode;

          lists[index.Value] = lists[index.Value].next;

          currentNode = currentNode.next;
        }
        while (index != null);

        return node.next;
      }

      private int? GetMinListIndex(ListNode[] lists)
      {
        int? min = null;
        int? index = null;

        for (var i = 0; i < lists.Length; i++)
        {
          if (lists[i] != null)
          {
            if (min == null || min > lists[i].val)
            {
              min = lists[i].val;
              index = i;
            }
          }
        }

        return index;
      }
    }
  }
}

