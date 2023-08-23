namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-unequal-triplets-in-array/
///    Submission: https://leetcode.com/problems/number-of-unequal-triplets-in-array/submissions/847002403/
/// </summary>
internal class P2475
{
  public class Solution
  {
    public int UnequalTriplets(int[] nums)
    {
      var ans = 0;

      for (int i = 0; i < nums.Length - 2; i++)
        for (int j = i + 1; j < nums.Length - 1; j++)
          for (int z = j + 1; z < nums.Length; z++)
            if (nums[i] != nums[j] && nums[j] != nums[z] && nums[i] != nums[z])
              ans++;

      return ans;
    }
  }
}
