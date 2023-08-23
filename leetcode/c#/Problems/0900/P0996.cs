namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-squareful-arrays/
///    Submission: https://leetcode.com/submissions/detail/724663611/
/// </summary>
internal class P0996
{
  public class Solution
  {
    public int NumSquarefulPerms(int[] nums)
    {
      var adj = new List<int>[nums.Length];

      Array.Sort(nums);

      for (var i = 0; i < nums.Length; i++)
      {
        adj[i] = new List<int>();

        for (int j = 0; j < nums.Length; j++)
        {
          if (i == j)
            continue;

          var sum = nums[i] + nums[j];
          var intSqrt = Convert.ToInt32(Math.Sqrt(sum));

          if (intSqrt * intSqrt == sum)
          {
            adj[i].Add(j);
          }
        }

        adj[i].Sort();
      }

      // graph
      // dfs

      var visited = new int[nums.Length];

      var ans = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        if (i > 0 && nums[i] == nums[i - 1])
          continue;

        visited[i] = 1;

        var res = DFS(0, i, visited, adj, nums);

        visited[i] = 0;

        ans += res;
      }

      return ans;
    }

    private int DFS(int step, int index, int[] visited, List<int>[] adj, int[] nums)
    {
      if (step == visited.Length - 1)
      {
        return 1;
      }

      var res = 0;
      var prev = -1;

      for (var i = 0; i < adj[index].Count; i++)
      {
        var next = adj[index][i];

        if (i > 0 && nums[adj[index][i]] == prev)
          continue;

        if (visited[next] == 1)
          continue;

        visited[next] = 1;

        res += DFS(step + 1, next, visited, adj, nums);
        prev = nums[adj[index][i]];

        visited[next] = 0;
      }

      return res;
    }
  }
}
