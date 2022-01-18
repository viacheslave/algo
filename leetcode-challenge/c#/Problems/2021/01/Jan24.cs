namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3615/
  ///    https://leetcode.com/submissions/detail/447101728/?from=explore&item_id=3615
  /// </summary>
  internal class Jan24
  {
    /**
    /* Definition for singly-linked list. */
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

    public class Solution
    {
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

