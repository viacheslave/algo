using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-root-of-n-ary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/459827299/
  ///    Google
  /// </summary>
  internal class P1506
  {
    public class Solution
    {
      public NodeChildren FindRoot(List<NodeChildren> tree)
      {
        var parents = new List<int>();

        foreach (var node in tree)
          foreach (var child in node.children)
            parents.Add(child.val);

        var parentSet = parents.ToHashSet();

        return tree.First(c => !parentSet.Contains(c.val));
      }
    }
  }
}
