namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/compare-version-numbers/
///    Submission: https://leetcode.com/submissions/detail/229316808/
/// </summary>
internal class P0165
{
  public class Solution
  {
    public int CompareVersion(string version1, string version2)
    {
      var ch1 = version1.Split('.');
      var ch2 = version2.Split('.');

      int res = 0;

      for (var i = 0; i < Math.Max(ch1.Length, ch2.Length); i++)
      {
        var c1 = i >= ch1.Length ? 0 : int.Parse(ch1[i].ToString());
        var c2 = i >= ch2.Length ? 0 : int.Parse(ch2[i].ToString());

        var comp = c1.CompareTo(c2);

        if (comp != 0)
          return comp;
      }

      return 0;
    }
  }
}
