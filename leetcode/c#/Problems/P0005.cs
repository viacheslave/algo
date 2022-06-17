namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-palindromic-substring/
///    Submission: https://leetcode.com/submissions/detail/237796018/
/// </summary>
internal class P0005
{
  public class Solution
  {
    public string LongestPalindrome(string s)
    {
      if (string.IsNullOrEmpty(s))
        return "";

      if (s.Length == 1)
        return s;

      ReadOnlySpan<char> sub = s[0..1];

      for (var i = 0; i < s.Length; i++)
      {
        var left = i;
        var right = i + 1;

        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
          if (right - left + 1 > sub.Length)
          {
            sub = s[left..(right + 1)];
          }

          left--;
          right++;
        }

        left = i;
        right = i + 2;

        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
          if (right - left + 1 > sub.Length)
          {
            sub = s[left..(right + 1)];
          }

          left--;
          right++;
        }
      }

      return sub.ToString();
    }
  }
}
