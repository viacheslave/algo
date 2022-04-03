namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-palindrome-with-fixed-length/
///    Submission: https://leetcode.com/submissions/detail/672344248/
/// </summary>
internal class P2217
{
  public class Solution
  {
    public long[] KthPalindrome(int[] queries, int intLength)
    {
      var length = intLength % 2 == 0 ? (intLength / 2) : (intLength / 2 + 1);
      var n = (long)Math.Pow(10, length - 1);

      var ans = new long[queries.Length];

      for (var i = 0; i < queries.Length; i++)
      {
        var query = queries[i];
        var inc = query - 1;
        var num = n;
        var upper = num * 10;

        var candidate = num + inc;
        if (candidate >= upper)
        {
          ans[i] = -1;
          continue;
        }

        var str = new string(candidate.ToString().Reverse().ToArray());
        if (intLength % 2 == 1)
          str = str[1..];

        ans[i] = long.Parse(candidate.ToString() + str);
      }

      return ans;
    }
  }

}
