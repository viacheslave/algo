namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/frog-jump/
///    Submission: https://leetcode.com/submissions/detail/585214381/
/// </summary>
internal class P0403
{
  public class Solution
  {
    public bool CanCross(int[] stones)
    {
      var set = stones.ToHashSet();
      var visited = new HashSet<(int value, int k)>();

      var ans = CanCross(set, stones[0], stones[stones.Length - 1], 1, visited, new[] { 1 });

      return ans;
    }

    private bool CanCross(HashSet<int> set, int current, int target, int k, HashSet<(int value, int k)> visited, int[] jumps)
    {
      if (visited.Contains((current, k)))
        return false;

      if (current == target)
        return true;

      foreach (var nk in jumps)
      {
        if (nk == 0)
          continue;

        var next = current + nk;
        if (next > target)
          continue;

        if (!set.Contains(next))
          continue;

        var res = CanCross(set, next, target, nk, visited, new[] { nk + 1, nk, nk - 1 });
        if (res)
          return true;
      }

      visited.Add((current, k));

      return false;
    }
  }
}
