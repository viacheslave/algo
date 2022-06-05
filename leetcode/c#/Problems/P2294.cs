namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/partition-array-such-that-maximum-difference-is-k/
///    Submission: https://leetcode.com/submissions/detail/714813397/
/// </summary>
internal class P2294
{
  public class Solution
  {
    public int PartitionArray(int[] nums, int k)
    {
      // greedy
      // sort the array and split it in subarrays

      Array.Sort(nums);

      var ans = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        var index = i;
        var el = nums[i];

        while (el - nums[i] <= k)
        {
          index++;
          if (index == nums.Length)
            break;

          el = nums[index];
        }

        i = index - 1;
        ans++;
      }

      return ans;
    }
  }
}
