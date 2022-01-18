namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-number-after-mutating-substring/
///    Submission: https://leetcode.com/submissions/detail/528036027/
/// </summary>
internal class P1946
{
  public class Solution
  {
    public string MaximumNumber(string num, int[] change)
    {
      var sb = new StringBuilder(num);

      var start = -1;

      for (var i = 0; i < num.Length; i++)
      {
        var chi = int.Parse(num[i].ToString());

        if (start == -1)
        {
          if (chi < change[chi])
          {
            start = i;
          }
        }

        if (start != -1)
        {
          if (chi <= change[chi])
          {
            sb[i] = change[chi].ToString()[0];
          }
          else
          {
            break;
          }
        }
      }

      return sb.ToString();
    }
  }
}
