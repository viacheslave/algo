namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-sort-a-binary-tree-by-level/
///    Submission: https://leetcode.com/problems/maximum-number-of-non-overlapping-palindrome-substrings/submissions/842880897/
/// </summary>
internal class P2471
{
  /**
   * Definition for a binary tree node.
   * public class TreeNode {
   *     public int val;
   *     public TreeNode left;
   *     public TreeNode right;
   *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
   *         this.val = val;
   *         this.left = left;
   *         this.right = right;
   *     }
   * }
   */
  public class Solution
  {
    public int MinimumOperations(TreeNode root)
    {
      var levels = new List<List<int>>();

      DFS(root, 0, levels);

      var ans = 0;

      // simulation
      foreach (var actual in levels)
      {
        var expected = actual.OrderBy(x => x).ToList();
        var actualMap = actual.Select((x, i) => (x, i)).ToDictionary(x => x.x, x => x.i);

        for (int i = 0; i < actual.Count; i++)
        {
          if (actual[i] != expected[i])
          {
            var v1 = actual[i];
            var v2 = expected[i];

            var index = actualMap[expected[i]];

            // swap
            var temp = actual[i];
            actual[i] = actual[index];
            actual[index] = temp;

            actualMap[v1] = index;
            actualMap[v2] = i;
            ans++;
          }
        }
      }

      return ans;
    }

    private void DFS(TreeNode node, int i, List<List<int>> levels)
    {
      if (node is null)
        return;

      if (i >= levels.Count)
        levels.Add(new List<int>());

      levels[i].Add(node.val);

      DFS(node.left, i + 1, levels);
      DFS(node.right, i + 1, levels);
    }
  }
}
