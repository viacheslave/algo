namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-1-bits/
///    Submission: https://leetcode.com/submissions/detail/227854276/
/// </summary>
internal class P0191
{
  public class Solution
  {
    public int HammingWeight(uint n)
    {
      var i = 32;

      int res = 0;
      while (i-- > 0)
      {
        if ((n % 2) == 1)
          res++;

        n = n >> 1;
      }


      return res;
    }
  }
}
