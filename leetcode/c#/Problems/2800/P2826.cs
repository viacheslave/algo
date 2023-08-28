namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sorting-three-groups/
///    Submission: https://leetcode.com/problems/sorting-three-groups/submissions/1032259854/
/// </summary>
internal class P2826
{
  public class Solution
  {
    public int MinimumOperations(IList<int> nums)
    {
      var n = nums.Count;
      var prefixSum = new int[3 + 1, n + 1];

      for (int i = 0; i < n; i++)
      {
        for (int element = 1; element <= 3; element++)
        {
          prefixSum[element, i + 1] = (nums[i] == element)
            ? prefixSum[element, i] + 1
            : prefixSum[element, i];
        }
      }

      var ans = int.MaxValue;

      for (int a = -1; a < n; a++)
      {
        for (int b = a; b < n; b++)
        {
          var ops = 0;

          // calc 1
          if (a >= 0)
            ops += Math.Abs(prefixSum[1, a + 1] - (a + 1));

          // calc 3
          if (b < n - 1)
            ops += Math.Abs(prefixSum[3, n] - prefixSum[3, b + 1] - (n - 1 - b));

          // calc 2
          if (a != b)
            ops += Math.Abs(prefixSum[2, b + 1] - prefixSum[2, a + 1] - (b - a));

          ans = Math.Min(ans, ops);
        }
      }

      return ans;
    }
  }
}
