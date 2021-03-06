namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/three-consecutive-odds/
///    Submission: https://leetcode.com/submissions/detail/387676050/
/// </summary>
internal class P1550
{
  public class Solution
  {
    public bool ThreeConsecutiveOdds(int[] arr)
    {
      if (arr.Length < 3)
        return false;

      for (var i = 0; i < arr.Length - 2; i++)
        if ((arr[i] % 2) == 1 && (arr[i + 1] % 2) == 1 && (arr[i + 2] % 2) == 1)
          return true;

      return false;
    }
  }
}
