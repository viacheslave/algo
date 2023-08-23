namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-substring-without-repeating-characters/
///    Submission: https://leetcode.com/submissions/detail/229150738/
/// </summary>
internal class P0003
{
  public class Solution
  {
    public int LengthOfLongestSubstring(string s)
    {
      if (string.IsNullOrEmpty(s))
        return 0;

      var hs = new Dictionary<char, int>();

      var max = 0;
      var firstCh = 0;

      for (var i = 0; i < s.Length; i++)
      {
        if (hs.ContainsKey(s[i]))
        {
          var newfirst = hs[s[i]] + 1;

          for (var j = firstCh; j <= hs[s[i]] - 1; j++)
          {
            hs.Remove(s[j]);
          }

          firstCh = newfirst;
          hs[s[i]] = i;
          continue;
        }

        hs[s[i]] = i;

        if (max < (i - firstCh + 1))
          max = i - firstCh + 1;
      }

      return max;
    }
  }
}
