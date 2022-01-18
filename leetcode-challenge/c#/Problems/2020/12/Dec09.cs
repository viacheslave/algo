using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3560/
  ///    https://leetcode.com/submissions/detail/428832682/?from=explore&item_id=3560
  /// </summary>
  internal class Dec09
  {
    /**
     * Definition for a binary tree node.*/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
     
    public class BSTIterator
    {
      TreeNode _root;
      Stack<TreeNode> _st = new Stack<TreeNode>();

      public BSTIterator(TreeNode root)
      {
        _root = root;

        Traverse(root, _st);
      }

      private void Traverse(TreeNode node, Stack<TreeNode> st)
      {
        if (node == null) return;

        Traverse(node.right, st);
        st.Push(node);
        Traverse(node.left, st);
      }

      /** @return the next smallest number */
      public int Next()
      {
        return _st.Pop().val;
      }

      /** @return whether we have a next smallest number */
      public bool HasNext()
      {
        return _st.Count > 0;
      }
    }

    /**
     * Your BSTIterator object will be instantiated and called as such:
     * BSTIterator obj = new BSTIterator(root);
     * int param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
  }
}
