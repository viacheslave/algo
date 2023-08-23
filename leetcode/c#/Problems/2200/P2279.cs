namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks/
///    Submission: https://leetcode.com/submissions/detail/705319573/
/// </summary>
internal class P2279
{
  public class Solution
  {
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
    {
      var cr = Enumerable
        .Range(0, capacity.Length)
        .Select(i => (c: capacity[i], r: rocks[i]))
        .OrderBy(e => e.c - e.r)
        .ToArray();

      var ans = 0;

      for (var i = 0; i < capacity.Length; i++)
      {
        if (cr[i].c - cr[i].r <= additionalRocks)
        {
          ans++;
          additionalRocks -= (cr[i].c - cr[i].r);
        }
        else
        {
          break;
        }
      }

      return ans;
    }
  }
}
