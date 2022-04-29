namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/calculate-digit-sum-of-a-string/
///    Submission: https://leetcode.com/submissions/detail/689651422/
/// </summary>
internal class P2243
{
  public class Solution
  {
    public string DigitSum(string s, int k)
    {
      var sb = new StringBuilder();

      while (s.Length > k)
      {
        var sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
          sum += int.Parse(s[i].ToString());

          if ((i > 0 && (i + 1) % k == 0) || i == s.Length - 1)
          {
            sb.Append(sum.ToString());
            sum = 0;
          }
        }

        s = sb.ToString();
        sb.Clear();
      }

      return s;
    }
  }
}
