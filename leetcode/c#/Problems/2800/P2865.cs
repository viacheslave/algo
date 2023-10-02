namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/beautiful-towers-i/
///    Submission: https://leetcode.com/problems/beautiful-towers-i/submissions/1064800662/
/// </summary>
internal class P2865
{
  public class Solution
  {
    public long MaximumSumOfHeights(IList<int> maxHeights)
    {
      var ans = long.MinValue;

      for (int i = 0; i < maxHeights.Count; i++)
      {
        var sum = 1L * maxHeights[i];
        var current = maxHeights[i];

        for (int j = i - 1; j >= 0; j--)
        {
          var el = Math.Min(maxHeights[j], current);
          current = el;

          sum += el;
        }

        current = maxHeights[i];
        for (int j = i + 1; j < maxHeights.Count; j++)
        {
          var el = Math.Min(maxHeights[j], current);
          current = el;

          sum += el;
        }

        ans = Math.Max(ans, sum);
      }

      return ans;
    }
  }
}
