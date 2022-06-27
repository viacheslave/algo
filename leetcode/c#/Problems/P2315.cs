namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-asterisks/
///    Submission: https://leetcode.com/submissions/detail/731149045/
/// </summary>
internal class P2315
{
  public class Solution
  {
    public int CountAsterisks(string s)
    {
      var flag = 0;

      var ans = 0;

      for (var i = 0; i < s.Length; i++)
      {
        if (s[i] == '|')
        {
          flag = 1 - flag;
        }

        if (s[i] == '*' && flag == 0)
        {
          ans++;
        }
      }

      return ans;
    }
  }
}
