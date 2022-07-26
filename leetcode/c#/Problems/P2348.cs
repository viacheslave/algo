namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-zero-filled-subarrays/
///    Submission: https://leetcode.com/submissions/detail/755496102/
/// </summary>
internal class P2348
{
  public class Solution
  {
    public long ZeroFilledSubarray(int[] nums)
    {
      var starts = new List<int>();
      var ends = new List<int>();

      if (nums[0] == 0)
        starts.Add(0);

      for (var i = 0; i < nums.Length - 1; i++)
      {
        if (nums[i] != 0 && nums[i + 1] == 0)
        {
          starts.Add(i + 1);
        }

        if (nums[i] == 0 && nums[i + 1] != 0)
        {
          ends.Add(i);
        }
      }

      if (nums[^1] == 0)
        ends.Add(nums.Length - 1);

      var ans = 0L;

      for (int i = 0; i < starts.Count; i++)
      {
        var length = ends[i] - starts[i] + 1;
        var count = 1L * length * (length + 1) / 2;

        ans += count;
      }

      return ans;
    }
  }
}
