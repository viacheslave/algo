using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/598/week-1-may-1st-may-7th/3733/
  /// 
  /// </summary>
  internal class May06
  {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public class Solution
    {
      public TreeNode SortedListToBST(ListNode head)
      {

        if (head == null)
          return null;

        var list = new List<int>() { head.val };

        var current = head.next;
        while (current != null)
        {
          list.Add(current.val);
          current = current.next;
        }

        return SortedArrayToBST(list.ToArray());
      }

      public TreeNode SortedArrayToBST(int[] nums)
      {
        if (nums.Length == 0)
          return null;

        if (nums.Length == 1)
          return new TreeNode(nums[0]);

        return Fill(nums, 0, nums.Length - 1);
        ;
      }

      private TreeNode Fill(int[] nums, int start, int end)
      {
        var middle = (end + start) / 2;
        var node = new TreeNode(nums[middle]);

        if (start == end)
          return node;

        if (start != middle)
          node.left = Fill(nums, start, middle - 1);

        if (middle != end)
          node.right = Fill(nums, middle + 1, end);


        return node;
      }
    }
  }
}
