namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-score-of-all-prefixes-of-an-array/
///    Submission: https://leetcode.com/problems/find-the-score-of-all-prefixes-of-an-array/submissions/958964453/
/// </summary>
internal class P2640
{
  public class Solution
  {
    public long[] FindPrefixScore(int[] nums)
    {
      int max = 0;
      long conver = 0;

      var ans = new long[nums.Length];

      for (int i = 0; i < nums.Length; i++)
      {
        max = Math.Max(max, nums[i]);
        var c = max + nums[i];

        conver += c;
        ans[i] = conver;
      }

      return ans;
    }
  }
}
