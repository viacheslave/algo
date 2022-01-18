using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Naive
{
  class Program
  {
    static void Main(string[] args)
    {
      //var r = new Solution()
      //  .TwoSumLessThanK(new int[] { 34, 23, 1, 24, 75, 33, 54, 8 }, 60
      // );

      //var root = new TreeNode(1);
      //root.left = new TreeNode(3);
      //root.right = new TreeNode(2);

      var r = new Solution()
        .KillProcess(new List<int> { 1, 3, 10, 5 }, new List<int> { 3, 0, 5, 3 }, 5);
    }
  }

  public class Solution
  {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
      var parents = new Dictionary<TreeNode, TreeNode>();
      Rec(root, null, parents);

      if (!parents.ContainsKey(p) || !parents.ContainsKey(q))
        return null;

      var pmap = new Dictionary<TreeNode, int>();
      var qmap = new Dictionary<TreeNode, int>();

      var current = p;
      var index = 0;
      while (current != null)
      {
        pmap[current] = 0;
        index++;
        current = parents[current];
      }

      current = q;
      index = 0;
      while (current != null)
      {
        qmap[current] = 0;
        index++;
        current = parents[current];
      }

      var min = int.MaxValue;
      var ans = default(TreeNode);

      foreach (var node in pmap)
      {
        if (qmap.ContainsKey(node.Key))
        {
          if (min > (pmap[node.Key] + qmap[node.Key]))
          {
            min = pmap[node.Key] + qmap[node.Key];
            ans = node.Key;
          }
        }
      }

      return ans;

    }

    private void Rec(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parents)
    {
      if (node == null)
        return;

      parents[node] = parent;
      Rec(node.left, node, parents);
      Rec(node.right, node, parents);
    }
  }
  /*
  public class Solution
  {
    public Node1 LowestCommonAncestor(Node1 p, Node1 q)
    {
      var pmap = new Dictionary<Node1, int>();
      var qmap = new Dictionary<Node1, int>();

      var current = p;
      var index = 0;
      while (current != null)
      {
        pmap[current] = 0;
        index++;
        current = current.parent;
      }

      current = q;
      index = 0;
      while (current != null)
      {
        qmap[current] = 0;
        index++;
        current = current.parent;
      }

      var min = int.MaxValue;
      var ans = default(Node1);

      foreach (var node in pmap)
      {
        if (qmap.ContainsKey(node.Key))
        {
          if (min > (pmap[node.Key] + qmap[node.Key]))
          {
            min = pmap[node.Key] + qmap[node.Key];
            ans = node.Key;
          }
        }
      }

      return ans;
    }
  }
  */
}

