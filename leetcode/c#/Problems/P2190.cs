namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/most-frequent-number-following-key-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/689852430/
/// </summary>
internal class P2190
{
  public class Solution
  {
    public int MostFrequent(int[] nums, int key)
    {
      var map = new Dictionary<int, int>();

      for (var i = 0; i < nums.Length - 1; i++)
      {
        if (nums[i] == key)
        {
          if (!map.ContainsKey(nums[i + 1]))
          {
            map[nums[i + 1]] = 0;
          }

          map[nums[i + 1]]++;
        }
      }

      return map.OrderByDescending(x => x.Value).First().Key;
    }
  }
}
