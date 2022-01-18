using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3780/
  /// 
  /// </summary>
  internal class Jun15
  {
    public class Solution
    {
      public bool Makesquare(int[] nums)
      {
        if (nums.Length == 0)
          return false;

        var sum = nums.Sum() / 4;

        if (nums.Sum() % 4 != 0)
          return false;

        nums = nums.OrderByDescending(x => x).ToArray();

        var bucketSum = Enumerable.Repeat(0, 4).ToArray();
        var ans = Rec(nums, sum, bucketSum, 0);

        return ans;
      }

      private bool Rec(int[] nums, int sum, int[] bucketSum, int index)
      {
        if (index == nums.Length)
          return bucketSum.All(d => d == sum);

        var ans = false;

        for (var bi = 0; bi < bucketSum.Length; bi++)
        {
          if (bucketSum[bi] == sum)
            continue;

          if (bucketSum[bi] + nums[index] <= sum)
          {
            bucketSum[bi] += nums[index];

            ans |= Rec(nums, sum, bucketSum, index + 1);
            if (ans)
              return true;

            bucketSum[bi] -= nums[index];
          }
        }

        return false;
      }
    }
  }
}
