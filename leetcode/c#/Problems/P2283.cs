namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value/
///    Submission: https://leetcode.com/submissions/detail/712082282/
/// </summary>
internal class P2283
{
  public class Solution
  {
    public bool DigitCount(string num)
    {
      var map = num
        .GroupBy(ch => int.Parse(ch.ToString()))
        .ToDictionary(x => x.Key, x => x.Count());

      for (var i = 0; i < num.Length; i++)
      {
        var digit = int.Parse(num[i].ToString());
        var occurs = map.GetValueOrDefault(i, 0);

        if (occurs != digit)
        {
          return false;
        }
      }

      return true;
    }
  }
}
