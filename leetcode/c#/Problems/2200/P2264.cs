namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-3-same-digit-number-in-string/
///    Submission: https://leetcode.com/submissions/detail/695580809/
/// </summary>
internal class P2264
{
  public class Solution
  {
    public string LargestGoodInteger(string num)
    {
      var ans = -1;

      for (var i = 0; i < num.Length - 2; i++)
      {
        if (num[i] == num[i + 1] && num[i + 1] == num[i + 2])
        {
          ans = Math.Max(ans, int.Parse(num.Substring(i, 3)));
        }
      }

      return ans == -1 ? "" : (ans == 0 ? "000" : ans.ToString());
    }
  }
}
