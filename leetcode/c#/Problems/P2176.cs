namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/644540304/
/// </summary>
internal class P2176
{
  public class Solution
  {
    public int CountPairs(int[] nums, int k)
    {
      var ans = 0;

      for (int i = 0; i < nums.Length - 1; i++)
      {
        for (int j = i + 1; j < nums.Length; j++)
        {
          if (nums[i] == nums[j] && ((i * j) % k == 0))
          {
            ans++;
          }
        }
      }

      return ans;
    }
  }
}
