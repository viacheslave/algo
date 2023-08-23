namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-ways-to-select-buildings/
///    Submission: https://leetcode.com/submissions/detail/675924769/
/// </summary>
internal class P2222
{
  public class Solution
  {
    public long NumberOfWays(string s)
    {
      var length = s.Length;
      var zeroLeft = new int[length + 1];
      var zeroRight = new int[length + 1];
      var oneLeft = new int[length + 1];
      var oneRight = new int[length + 1];

      for (var i = 0; i < length; i++)
      {
        if (s[i] == '0')
          zeroLeft[i + 1] = zeroLeft[i] + 1;
        else
          zeroLeft[i + 1] = zeroLeft[i];

        if (s[i] == '1')
          oneLeft[i + 1] = oneLeft[i] + 1;
        else
          oneLeft[i + 1] = oneLeft[i];
      }

      for (var i = length - 1; i >= 0; i--)
      {
        if (s[i] == '0')
          zeroRight[i] = zeroRight[i + 1] + 1;
        else
          zeroRight[i] = zeroRight[i + 1];

        if (s[i] == '1')
          oneRight[i] = oneRight[i + 1] + 1;
        else
          oneRight[i] = oneRight[i + 1];
      }

      var ans = 0L;

      for (var i = 0; i < length; i++)
      {
        if (s[i] == '0')
          ans += oneLeft[i] * oneRight[i];
        else
          ans += zeroLeft[i] * zeroRight[i];
      }

      return ans;
    }
  }
}
