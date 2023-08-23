namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-consecutive-floors-without-special-floors/
///    Submission: https://leetcode.com/submissions/detail/699944749/
/// </summary>
internal class P2274
{
  public class Solution
  {
    public int MaxConsecutive(int bottom, int top, int[] special)
    {
      if (special.Length == 0)
      {
        return top - bottom + 1;
      }

      if (special.Length == 1)
      {
        var sp = special[0];
        var left = Math.Max((sp - 1) - bottom + 1, 0);
        var right = Math.Max(top - (sp + 1) + 1, 0);

        return Math.Max(left, right);
      }

      Array.Sort(special);

      var ans = 0;
      var l = Math.Max((special[0] - 1) - bottom + 1, 0);
      var r = Math.Max(top - (special[^1] + 1) + 1, 0);

      ans = Math.Max(ans, l);
      ans = Math.Max(ans, r);

      for (var i = 1; i < special.Length; i++)
      {
        ans = Math.Max(ans, special[i] - special[i - 1] - 1);
      }

      return ans;
    }
  }
}
