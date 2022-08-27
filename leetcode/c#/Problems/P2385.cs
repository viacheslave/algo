namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/amount-of-time-for-binary-tree-to-be-infected/
///    Submission: https://leetcode.com/submissions/detail/781998902/
/// </summary>
internal class P2385
{
  public class Solution
  {
    public int AmountOfTime(TreeNode root, int start)
    {
      // build adj list

      var adj = new Dictionary<int, List<int>>();

      BuildAdj(root, null, adj);

      // dfs

      var stack = new Stack<(int value, int rank)>();
      stack.Push((start, 0));

      var ans = 0;
      var visited = new HashSet<int>();

      while (stack.Count > 0)
      {
        var item = stack.Pop();
        if (visited.Contains(item.value))
          continue;

        visited.Add(item.value);

        ans = Math.Max(ans, item.rank);

        foreach (var a in adj[item.value])
        {
          stack.Push((a, item.rank + 1));
        }
      }

      return ans;
    }

    private void BuildAdj(TreeNode node, TreeNode parent, Dictionary<int, List<int>> adj)
    {
      if (node is null)
        return;

      adj[node.val] = new List<int>();

      if (parent != null)
        adj[node.val].Add(parent.val);

      if (node.left is not null)
        adj[node.val].Add(node.left.val);

      if (node.right is not null)
        adj[node.val].Add(node.right.val);

      BuildAdj(node.left, node, adj);
      BuildAdj(node.right, node, adj);
    }
  }
}
