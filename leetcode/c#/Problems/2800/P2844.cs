namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/minimum-operations-to-make-a-special-number/
///    Submission: https://leetcode.com/problems/minimum-operations-to-make-a-special-number/submissions/1048534949/
/// </summary>
internal class P2844
{
  public class Solution
  {
    public int MinimumOperations(string num)
    {
      var ans = num.Length;

      var last0 = num.LastIndexOf('0');

      if (last0 != -1)
      {
        var last05 = num[..last0].LastIndexOfAny(new[] { '0', '5' });
        if (last05 != -1)
        {
          ans = Math.Min(ans, num.Length - last05 - 1 - 1);
        }
        else
        {
          ans = Math.Min(ans, num.Length - num.Count(s => s == '0'));
        }
      }

      var last5 = num.LastIndexOf('5');

      if (last5 != -1)
      {
        var last27 = num[..last5].LastIndexOfAny(new[] { '2', '7' });
        if (last27 != -1)
        {
          ans = Math.Min(ans, num.Length - last27 - 1 - 1);
        }
      }

      return ans;
    }
  }
}
