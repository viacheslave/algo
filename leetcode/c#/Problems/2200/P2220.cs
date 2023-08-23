namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-bit-flips-to-convert-number/
///    Submission: https://leetcode.com/submissions/detail/689663304/
/// </summary>
internal class P2220
{
  public class Solution
  {
    public int MinBitFlips(int start, int goal)
    {
      var xor = start ^ goal;

      var ans = 0;
      while (xor > 0)
      {
        if (xor % 2 == 1)
        {
          ans++;
        }
        xor >>= 1;
      }

      return ans;
    }
  }
}
