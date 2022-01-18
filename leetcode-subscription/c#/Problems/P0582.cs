using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kill-process/
  ///    Submission: https://leetcode.com/submissions/detail/460651386/
  ///    Bloomberg
  /// </summary>
  internal class P0582
  {
    public class Solution
    {
      public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
      {
        var nodes = new Dictionary<int, N>();

        for (var i = 0; i < pid.Count; i++)
        {
          var id = pid[i];
          var parentId = ppid[i];

          nodes.TryGetValue(parentId, out var parentNode);
          if (parentNode == null)
          {
            parentNode = new N();
            parentNode.Id = parentId;
            nodes.Add(parentNode.Id, parentNode);
          }

          nodes.TryGetValue(id, out var node);
          if (node == null)
          {
            node = new N();
            node.Id = id;
            nodes.Add(node.Id, node);
          }

          parentNode.Children.Add(node);
        }

        var startNode = nodes[kill];
        var ans = new List<int>();

        Rec(startNode, ans);

        return ans;
      }

      private void Rec(N node, List<int> ans)
      {
        ans.Add(node.Id);
        foreach (var child in node.Children)
          Rec(child, ans);
      }

      public class N
      {
        public int Id { get; set; }
        public List<N> Children { get; } = new List<N>();
      }
    }
  }
}
