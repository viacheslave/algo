namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3609/
  ///    https://leetcode.com/submissions/detail/447103221/?from=explore&item_id=3609
  /// </summary>
  internal class Jan19
  {
    public class Solution
    {
      public string LongestPalindrome(string s)
      {
        if (string.IsNullOrEmpty(s))
          return "";

        if (s.Length == 1)
          return s;

        var sub = s[0].ToString();

        for (var i = 0; i < s.Length; i++)
        {
          var left = i;
          var right = i + 1;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            if (right - left + 1 > sub.Length)
              sub = s.Substring(left, right - left + 1);

            left--;
            right++;
          }

          left = i;
          right = i + 2;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            if (right - left + 1 > sub.Length)
              sub = s.Substring(left, right - left + 1);

            left--;
            right++;
          }
        }

        return sub;
      }
    }
  }
}

