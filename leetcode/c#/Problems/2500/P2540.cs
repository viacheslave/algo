namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-common-value/
///    Submission: https://leetcode.com/problems/minimum-common-value/submissions/900978790/
/// </summary>
internal class P2540
{
  public class Solution
  {
    public int GetCommon(int[] nums1, int[] nums2)
    {
      var set = nums1.ToHashSet();
      set.IntersectWith(nums2);

      if (set.Count == 0)
        return -1;

      return set.OrderBy(d => d).First();
    }
  }
}
