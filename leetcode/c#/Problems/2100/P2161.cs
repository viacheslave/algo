namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/partition-array-according-to-given-pivot/
///    Submission: https://leetcode.com/submissions/detail/635090585/
/// </summary>
internal class P2161
{
  public class Solution
  {
    public int[] PivotArray(int[] nums, int pivot)
    {
      // 9,12,5,10,14,3,10

      var n = nums.Length;

      var pivots = nums.Count(x => x == pivot);
      var left = nums.Where(x => x < pivot).ToArray();
      var right = nums.Where(x => x > pivot).ToArray();

      for (var i = 0; i < left.Length; i++)
        nums[i] = left[i];

      for (var i = 0; i < right.Length; i++)
        nums[n - 1 - i] = right[right.Length - 1 - i];

      if (pivots > 0)
      {
        for (var i = 0; i < pivots; i++)
          nums[left.Length + i] = pivot;
      }

      return nums;
    }
  }
}
