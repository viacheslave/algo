namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/min-max-game/
///    Submission: https://leetcode.com/submissions/detail/714816788/
/// </summary>
internal class P2293
{
  public class Solution
  {
    public int MinMaxGame(int[] nums)
    {
      while (nums.Length > 1)
      {
        var newNums = new int[nums.Length / 2];

        for (var i = 0; i < nums.Length; i += 2)
        {
          var index = i / 2;
          if (index % 2 == 0)
          {
            newNums[index] = Math.Min(nums[i], nums[i + 1]);
          }
          else
          {
            newNums[index] = Math.Max(nums[i], nums[i + 1]);
          }
        }

        nums = newNums;
      }

      return nums[0];
    }
  }
}
