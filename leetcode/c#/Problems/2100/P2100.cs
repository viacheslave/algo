namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-good-days-to-rob-the-bank/
///    Submission: https://leetcode.com/submissions/detail/600356661/
/// </summary>
internal class P2100
{
  public class Solution
  {
    public IList<int> GoodDaysToRobBank(int[] security, int time)
    {
      var downs = new int[security.Length];
      var ups = new int[security.Length];

      for (var i = 1; i < security.Length; i++)
      {
        var val = security[i] - security[i - 1];

        downs[i] = downs[i - 1] + 1;
        ups[i] = ups[i - 1] + 1;

        if (val < 0)
        {
          ups[i] = 0;
        }

        if (val > 0)
        {
          downs[i] = 0;
        }
      }

      var ans = new List<int>();

      for (var i = time; i < security.Length - time; i++)
      {
        if (downs[i] >= time && ups[i + time] >= time)
          ans.Add(i);
      }

      return ans;
    }
  }

}
