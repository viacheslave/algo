namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-sum-of-four-digit-number-after-splitting-digits/
///    Submission: https://leetcode.com/submissions/detail/634995904/
/// </summary>
internal class P2160
{
  public class Solution
  {
    public int MinimumSum(int num)
    {
      var str = num.ToString();
      var chs = str.OrderBy(x => x).ToArray();

      var a1 = $"{chs[0]}{chs[2]}";
      var a2 = $"{chs[1]}{chs[3]}";

      return int.Parse(a1) + int.Parse(a2);
    }
  }
}
