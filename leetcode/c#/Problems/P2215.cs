namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-difference-of-two-arrays/
///    Submission: https://leetcode.com/submissions/detail/689664612/
/// </summary>
internal class P2215
{
  public class Solution
  {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
      return new List<IList<int>>() {
      nums1.ToHashSet().Except(nums2).ToHashSet().ToList(),
      nums2.ToHashSet().Except(nums1).ToHashSet().ToList()
    };
    }
  }
}
