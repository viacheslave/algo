namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/frog-jump-ii/
///    Submission: https://leetcode.com/problems/frog-jump-ii/submissions/859342757/
/// </summary>
internal class P2498
{
  public class Solution
  {
    public int MaxJump(int[] stones)
    {
      if (stones.Length == 2)
        return stones[^1];

      // greedy
      // just check all minimum gaps
      var ans = 0;

      for (var i = 0; i < stones.Length; i++)
      {
        if (i + 2 < stones.Length)
        {
          ans = Math.Max(ans, stones[i + 2] - stones[i]);
        }
      }

      for (var i = 1; i < stones.Length; i++)
      {
        if (i + 2 < stones.Length)
        {
          ans = Math.Max(ans, stones[i + 2] - stones[i]);
        }
      }

      return ans;
    }
  }
}
