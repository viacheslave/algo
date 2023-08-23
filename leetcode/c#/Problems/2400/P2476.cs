namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/closest-nodes-queries-in-a-binary-search-tree/
///    Submission: https://leetcode.com/problems/closest-nodes-queries-in-a-binary-search-tree/submissions/846966626/
/// </summary>
internal class P2476
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
    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
    {
      var arr = new List<int>();
      InOrder(arr, root);

      var ans = new List<IList<int>>();
      var set = arr.ToHashSet();

      foreach (var query in queries)
      {
        if (set.Contains(query))
        {
          ans.Add(new List<int> { query, query });
          continue;
        }

        var bisectIndex = Bisect(arr, query);

        int min = bisectIndex == 0 ? -1 : arr[bisectIndex - 1];
        int max = bisectIndex == arr.Count ? -1 : arr[bisectIndex];

        ans.Add(new List<int> { min, max });
      }

      return ans;
    }

    private int Bisect(List<int> arr, int query)
    {
      var lo = 0;
      var hi = arr.Count;

      while (lo < hi)
      {
        var mid = (lo + hi) / 2;
        if (arr[mid] < query)
          lo = mid + 1;
        else
          hi = mid;
      }

      return lo;
    }

    private void InOrder(List<int> arr, TreeNode node)
    {
      if (node is null)
        return;

      InOrder(arr, node.left);
      arr.Add(node.val);
      InOrder(arr, node.right);
    }
  }
}
