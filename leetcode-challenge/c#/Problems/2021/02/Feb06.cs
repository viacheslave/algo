using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3630/
  ///    https://leetcode.com/submissions/detail/453140659/?from=explore&item_id=3630
  /// </summary>
  internal class Feb06
  {
    /**
     * Definition for a binary tree node.*/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public class Solution
    {
      public IList<int> RightSideView(TreeNode root)
      {
        var res = new List<int>();
        if (root == null)
          return res;

        Traverse(root, res, 0);

        return res;
      }

      void Traverse(TreeNode node, List<int> res, int d)
      {
        if (node == null)
          return;

        if (res.Count < d + 1)
          res.Add(node.val);

        Traverse(node.right, res, d + 1);
        Traverse(node.left, res, d + 1);
      }
    }
  }
}
