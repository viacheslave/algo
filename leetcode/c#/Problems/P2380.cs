namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/time-needed-to-rearrange-a-binary-string/
///    Submission: https://leetcode.com/submissions/detail/781987975/
/// </summary>
internal class P2380
{
  public class Solution
  {
    public int SecondsToRemoveOccurrences(string s)
    {
      var sb = new StringBuilder(s);

      var ans = 0;

      while (true)
      {
        var flag = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
          if (sb[i] == '0' && sb[i + 1] == '1')
          {
            sb[i] = '1';
            sb[i + 1] = '0';
            i += 1;
            flag = 1;
          }
        }

        if (flag == 0)
          break;

        ans++;
      }

      return ans;
    }
  }
}
