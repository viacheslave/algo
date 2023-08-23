namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-operations-to-make-array-equal-ii/
///    Submission: https://leetcode.com/problems/minimum-operations-to-make-array-equal-ii/submissions/900977502/
/// </summary>
internal class P2541
{
  public class Solution
  {
    public long MinOperations(int[] nums1, int[] nums2, int k)
    {
      var length = nums1.Length;

      if (k == 0)
      {
        for (var i = 0; i < length; i++)
        {
          if (nums1[i] != nums2[i])
            return -1;
        }

        return 0;
      }

      var sum1 = nums1.Select(f => (long)f).Sum();
      var sum2 = nums2.Select(f => (long)f).Sum();

      if (sum1 != sum2)
        return -1;

      var diffs = Enumerable.Range(0, length)
        .Select(e => nums1[e] - (long)nums2[e])
        .ToArray();

      if (diffs.Any(e => e % k != 0))
        return -1;

      return diffs.Select(e => Math.Abs(e / k)).Sum() / 2;
    }
  }
}
