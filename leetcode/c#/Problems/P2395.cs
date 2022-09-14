namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-subarrays-with-equal-sum/
///    Submission: https://leetcode.com/submissions/detail/797216139/
/// </summary>
internal class P2395
{
  public class Solution
  {
    public bool FindSubarrays(int[] nums)
    {
      var sums = new HashSet<int>();

      for (int i = 1; i < nums.Length; i++)
      {
        var sum = int.Parse(nums[i].ToString()) + int.Parse(nums[i - 1].ToString());
        if (sums.Contains(sum))
        {
          return true;
        }

        sums.Add(sum);
      }

      return false;
    }
  }
}
