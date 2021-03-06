namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/monotonic-array/
///    Submission: https://leetcode.com/submissions/detail/231281150/
/// </summary>
internal class P0896
{
  public class Solution
  {
    public bool IsMonotonic(int[] A)
    {
      if (A.Length < 2)
        return true;

      bool inc = true;
      bool dec = true;

      for (var i = 0; i < A.Length - 1; i++)
      {
        var cur = A[i];
        var next = A[i + 1];

        inc = inc && (cur == next || cur < next);
        dec = dec && (cur == next || cur > next);
      }

      return inc || dec;
    }
  }
}
