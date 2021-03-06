namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/masking-personal-information
///    Submission: https://leetcode.com/submissions/detail/231516196/
/// </summary>
internal class P0831
{
  public class Solution
  {
    public string MaskPII(string S)
    {
      if (S.Contains('@'))
        return MaskEmail(S);

      return MaskPhone(S);
    }

    string MaskEmail(string s)
    {
      var fname = s.Substring(0, s.IndexOf('@')).ToLower();

      if (fname.Length >= 2)
      {
        fname = fname[0] + new string('*', 5) + fname[fname.Length - 1];
      }

      return fname + "@" + s.Substring(s.IndexOf('@') + 1).ToLower();

    }

    string MaskPhone(string s)
    {
      var stripped = s
          .Replace("(", "")
          .Replace(")", "")
          .Replace("-", "")
          .Replace("+", "")
          .Replace(" ", "");

      string country = null;

      if (stripped.Length > 10)
        country = "+" + new string('*', stripped.Length - 10);

      return (country == null ? string.Empty : (country + "-"))
              + "***-***-"
              + stripped.Substring(stripped.Length - 4);
    }
  }
}
