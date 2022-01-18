namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/median-of-two-sorted-arrays/
///    Submission: https://leetcode.com/submissions/detail/228083270/
/// </summary>
internal class P0004
{
  public class Solution
  {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
      int m1, m2;
      if ((nums1.Length + nums2.Length) % 2 == 0)
      {
        m1 = (nums1.Length + nums2.Length) / 2 - 1;
        m2 = m1 + 1;
      }
      else
      {
        m1 = m2 = (nums1.Length + nums2.Length) / 2;
      }

      int i1 = 0;
      int i2 = 0;

      var arr = new List<int>();

      while (i1 < nums1.Length || i2 < nums2.Length)
      {
        if (i1 < nums1.Length && i2 == nums2.Length)
        {
          arr.Add(nums1[i1]);
          i1++;
          continue;
        }

        if (i1 == nums1.Length && i2 < nums2.Length)
        {
          arr.Add(nums2[i2]);
          i2++;
          continue;
        }

        if (nums1[i1] > nums2[i2])
        {
          arr.Add(nums2[i2]);
          i2++;
          continue;
        }
        else
        {
          arr.Add(nums1[i1]);
          i1++;
          continue;
        }
      }

      return 1.0 * (arr[m1] + arr[m2]) / 2; ;
    }
  }
}
