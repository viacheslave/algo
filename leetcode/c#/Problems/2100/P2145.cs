namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-the-hidden-sequences/
///    Submission: https://leetcode.com/submissions/detail/625294355/
/// </summary>
/// <remarks>
///   Calculate min and max deviation against 0.
///   Then project it to lower and upper values.
/// </remarks>
internal class P2145
{
  public class Solution
  {
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
      var min = 0L;
      var max = 0L;

      var current = 0;

      for (int i = 0; i < differences.Length; i++)
      {
        current += differences[i];
        min = Math.Min(min, current);
        max = Math.Max(max, current);
      }

      if (max - min > upper - lower)
        return 0;

      return (int)((upper - lower) - (max - min)) + 1;
    }
  }
}
