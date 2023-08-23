namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-distinct-averages/
///    Submission: https://leetcode.com/problems/number-of-distinct-averages/submissions/842817790/
/// </summary>
internal class P2465
{
  public class Solution
  {
    public int DistinctAverages(int[] nums)
    {
      Array.Sort(nums);

      var set = new HashSet<double>();

      for (int i = 0; i < nums.Length / 2; i++)
      {
        set.Add((nums[i] + nums[nums.Length - i - 1]) / 2d);
      }

      return set.Count;
    }
  }
}
