namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-hills-and-valleys-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/689843498/
/// </summary>
internal class P2210
{
  public class Solution
  {
    public int CountHillValley(int[] nums)
    {
      var list = new List<int>();

      for (var i = 0; i < nums.Length; i++)
      {
        if (list.Count == 0 || list[^1] != nums[i])
        {
          list.Add(nums[i]);
        }
      }

      var ans = 0;

      if (list.Count <= 2)
      {
        return 0;
      }

      for (var i = 1; i < list.Count - 1; i++)
      {
        if (list[i - 1] > list[i] && list[i] < list[i + 1])
          ans++;

        if (list[i - 1] < list[i] && list[i] > list[i + 1])
          ans++;
      }

      return ans;
    }
  }
}
