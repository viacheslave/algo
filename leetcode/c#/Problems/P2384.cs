namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-palindromic-number/
///    Submission: https://leetcode.com/submissions/detail/782021173/
/// </summary>
internal class P2384
{
  public class Solution
  {
    public string LargestPalindromic(string num)
    {
      var map = num
        .GroupBy(d => d)
        .Select(d => (digit: d.Key, count: d.Count()))
        .OrderByDescending(d => d.digit)
        .ToList();

      if (map.Count == 1 && map.FirstOrDefault().digit == '0')
        return "0";

      var center = map.Where(d => d.count % 2 == 1).FirstOrDefault();

      var sb = new StringBuilder();

      foreach (var kvp in map)
      {
        if (sb.Length == 0 && kvp.count >= 2 && kvp.digit == '0')
          continue;

        if (kvp.count >= 2)
          sb.Append(kvp.digit, kvp.count / 2);
      }

      var leftPart = sb.ToString();

      var ans = leftPart;
      if (center != default)
        ans += center.digit;
      ans += string.Join("", leftPart.Reverse());

      return ans;
    }
  }
}
