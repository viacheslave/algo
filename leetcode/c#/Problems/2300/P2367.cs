namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-arithmetic-triplets/
///    Submission: https://leetcode.com/submissions/detail/773335040/
/// </summary>
internal class P2367
{
  public class Solution
  {
    public int ArithmeticTriplets(int[] nums, int diff)
    {
      var map = nums.GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count());

      var ans = 0;

      for (int i = 0; i < nums.Length - 1; i++)
      {
        for (int j = 1; j < nums.Length; j++)
        {
          var sum = nums[i] + nums[j];
          if (sum % 2 == 1)
            continue;

          var mid = sum / 2;
          if (map.ContainsKey(mid) && nums[j] - mid == diff)
          {
            ans += map[mid];
          }
        }
      }

      return ans;
    }
  }
}
