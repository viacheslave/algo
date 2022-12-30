namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-enemy-forts-that-can-be-captured/
///    Submission: https://leetcode.com/problems/maximum-enemy-forts-that-can-be-captured/submissions/865691260/
/// </summary>
internal class P2511
{
  public class Solution
  {
    public int CaptureForts(int[] forts)
    {
      var fortOrEmpty = forts
        .Select((f, i) => (f, i))
        .Where(o => o.f != 0)
        .Select(o => o.i)
        .ToList();

      var ans = 0;

      for (int i = 1; i < fortOrEmpty.Count; i++)
      {
        if (forts[fortOrEmpty[i]] + forts[fortOrEmpty[i - 1]] == 0)
        {
          ans = Math.Max(ans, fortOrEmpty[i] - fortOrEmpty[i - 1] - 1);
        }
      }

      return ans;
    }
  }
}
