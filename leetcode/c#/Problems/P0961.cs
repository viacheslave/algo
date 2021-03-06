namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/n-repeated-element-in-size-2n-array/
///    Submission: https://leetcode.com/submissions/detail/234322729/
/// </summary>
internal class P0961
{
  public class Solution
  {
    public int RepeatedNTimes(int[] A)
    {
      var h = new HashSet<int>();

      foreach (var e in A)
      {
        if (h.Contains(e))
          return e;

        h.Add(e);
      }

      return -1;
    }
  }
}
