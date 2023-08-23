namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-substring-with-maximum-cost/
///    Submission: https://leetcode.com/problems/find-the-substring-with-maximum-cost/submissions/926599772/
/// </summary>
internal class P2606
{
  public class Solution
  {
    public int MaximumCostSubstring(string s, string chars, int[] vals)
    {
      var mx = new int[s.Length];

      var values = chars.Zip(vals).ToDictionary(x => x.First, x => x.Second);

      for (int i = 0; i < s.Length; i++)
      {
        var value = values.GetValueOrDefault(s[i], s[i] - 97 + 1);

        if (i == 0)
        {
          mx[i] = value;
          continue;
        }

        mx[i] = Math.Max(mx[i - 1] + value, value);
      }

      return Math.Max(mx.Max(), 0);
    }
  }
}
