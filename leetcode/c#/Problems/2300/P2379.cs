namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/
///    Submission: https://leetcode.com/submissions/detail/781993518/
/// </summary>
internal class P2379
{
  public class Solution
  {
    public int MinimumRecolors(string blocks, int k)
    {
      // sliding window

      var b = blocks.Take(k).Count(c => c == 'B');
      var ans = b;

      for (int i = 1; i < blocks.Length - k + 1; i++)
      {
        if (blocks[i - 1] == 'B')
          b--;

        if (blocks[i - 1 + k] == 'B')
          b++;

        ans = Math.Max(ans, b);
      }

      return k - ans;
    }
  }
}
