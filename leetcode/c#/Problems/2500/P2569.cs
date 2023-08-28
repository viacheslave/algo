namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-score-by-changing-two-elements/
///    Submission: https://leetcode.com/problems/minimum-score-by-changing-two-elements/submissions/1033276110/
/// </summary>
internal class P2569
{
  public class Solution
  {
    public int MinimizeSum(int[] nums)
    {
      if (nums.Length == 3)
        return 0;

      Array.Sort(nums);

      var option1 = Math.Abs(nums[0] - nums[^3]);
      var option2 = Math.Abs(nums[2] - nums[^1]);
      var option3 = Math.Abs(nums[1] - nums[^2]);

      return new[] { option1, option2, option3 }.OrderBy(x => x).First();
    }
  }
}
