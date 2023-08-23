namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shifting-letters-ii/
///    Submission: https://leetcode.com/submissions/detail/781442898/
/// </summary>
internal class P2381
{
  public class Solution
  {
    public string ShiftingLetters(string s, int[][] shifts)
    {
      var sb = new StringBuilder(s);

      // combine all shifts

      var points = shifts
        .Select(shift => new[] { (shift[0], shift[2] == 1 ? 1 : -1), (shift[1] + 1, shift[2] == 1 ? -1 : 1) })
        .SelectMany(s => s)
        .GroupBy(s => s.Item1)
        .ToDictionary(s => s.Key, s => s.Select(d => d.Item2).Sum());

      var diff = 0;

      for (int i = 0; i < s.Length; i++)
      {
        if (points.ContainsKey(i))
        {
          diff += points[i];
        }

        sb[i] = (char)(((s[i] - 97 + (diff % 26) + 26) % 26) + 97);
      }

      return sb.ToString();
    }
  }

}
