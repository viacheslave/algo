namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-subarray-with-maximum-bitwise-and/
///    Submission: https://leetcode.com/submissions/detail/808142648/
/// </summary>
internal class P2419
{
  public class Solution
  {
    public int LongestSubarray(int[] nums)
    {
      // calculate intervals
      var starts = new List<int>();
      var ends = new List<int>();

      starts.Add(0);

      for (int i = 1; i < nums.Length; i++)
      {
        if (nums[i] != nums[i - 1])
        {
          starts.Add(i);
          ends.Add(i - 1);
        }
      }

      ends.Add(nums.Length - 1);

      // check values
      var intervals = starts.Zip(ends)
        .Select(item => (length: item.Second - item.First + 1, value: nums[item.First]))
        .OrderByDescending(item => item.value)
        .ThenByDescending(item => item.length)
        .ToArray();

      return intervals.Select(t => t.length).First();
    }
  }
}
