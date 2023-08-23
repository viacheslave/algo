namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/
///    Submission: https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/submissions/942549552/
/// </summary>
internal class P2657
{
  public class Solution
  {
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
      var C = new int[A.Length];

      var a = new List<int>();
      var b = new List<int>();

      for (int i = 0; i < A.Length; i++)
      {
        a.Add(A[i]);
        b.Add(B[i]);

        C[i] = a.Intersect(b).Count();
      }

      return C;
    }
  }

}
