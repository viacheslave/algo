namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/find-the-longest-semi-repetitive-substring/
///    Submission: https://leetcode.com/problems/find-the-longest-semi-repetitive-substring/submissions/978552606/
/// </summary>
internal class P2730
{
  public class Solution
  {
    public int LongestSemiRepetitiveSubstring(string s)
    {
      var fs = new List<int>();

      for (int i = 0; i < s.Length - 1; i++)
      {
        if (s[i] == s[i + 1])
          fs.Add(i);
      }

      if (fs.Count == 0)
        return s.Length;

      var ans = 0;

      for (int i = 0; i < fs.Count; i++)
      {
        var left = (i == 0) ? 0 : fs[i - 1] + 1;
        var right = (i == fs.Count - 1) ? s.Length - 1 : fs[i + 1];

        var length = right - left + 1;
        //if (s[left] == s[right])
        //  length--;

        ans = Math.Max(ans, length--);
      }

      return ans;
    }
  }
}
