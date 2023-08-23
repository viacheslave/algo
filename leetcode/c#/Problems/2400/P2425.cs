namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/bitwise-xor-of-all-pairings/
///    Submission: https://leetcode.com/problems/bitwise-xor-of-all-pairings/submissions/815170065/
/// </summary>
internal class P2425
{
  public class Solution
  {
    public int XorAllNums(int[] nums1, int[] nums2)
    {
      // even count is eliminated

      var xor1 = nums1.Aggregate(0, (a, item) => a ^ item);
      var xor2 = nums2.Aggregate(0, (a, item) => a ^ item);

      if (nums1.Length % 2 == 0 && nums2.Length % 2 == 0)
      {
        return 0;
      }

      if (nums1.Length % 2 == 0)
      {
        return xor1;
      }

      if (nums2.Length % 2 == 0)
      {
        return xor2;
      }

      return xor1 ^ xor2;
    }
  }
}
