namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/count-complete-subarrays-in-an-array/
///    Submission: https://leetcode.com/problems/count-complete-subarrays-in-an-array/submissions/1030439424/
/// </summary>
internal class P2799
{
  public class Solution
  {
    public int CountCompleteSubarrays(int[] nums)
    {
      // sliding window

      var ans = 0;
      var distinct = nums.Distinct().Count();

      if (distinct == 1)
      {
        return nums.Length * (nums.Length + 1) / 2;
      }

      var left = 0;
      var right = 0;
      var map = new Dictionary<int, int>();

      while (right < nums.Length)
      {
        Add(map, nums[right]);

        if (!IsValid(map, distinct))
        {
          right++;
          continue;
        }

        while (IsValid(map, distinct))
        {
          Remove(map, nums[left]);
          left++;
        }

        ans += left;

        left--;
        Add(map, nums[left]);

        right++;
      }

      return ans;
    }

    private static void Add(Dictionary<int, int> map, int num)
    {
      map.TryAdd(num, 0);
      map[num]++;
    }

    private static void Remove(Dictionary<int, int> map, int num)
    {
      map[num]--;
      if (map[num] == 0) map.Remove(num);
    }

    private static bool IsValid(Dictionary<int, int> map, int distinct) => map.Keys.Count == distinct;
  }

}
