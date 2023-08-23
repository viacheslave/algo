namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximize-greatness-of-an-array/
///    Submission: https://leetcode.com/problems/maximize-greatness-of-an-array/submissions/921792353/
/// </summary>
internal class P2592
{
  public class Solution
  {
    public int MaximizeGreatness(int[] nums)
    {
      // greedy

      if (nums.Length == 1)
        return 0;

      Array.Sort(nums);

      var other = 1;
      var ans = 0;

      for (int i = 0; i < nums.Length; i++)
      {
        while (other < nums.Length && nums[other] <= nums[i])
          other++;

        if (other == nums.Length)
          break;

        ans++;
        other++;
      }

      return ans;
    }
  }
}
