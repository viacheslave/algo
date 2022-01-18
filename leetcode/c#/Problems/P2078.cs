namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/two-furthest-houses-with-different-colors/
///    Submission: https://leetcode.com/submissions/detail/590624905/
/// </summary>
internal class P2078
{
  public class Solution
  {
    public int MaxDistance(int[] colors)
    {
      var max = 1;

      // Brute force every pair
      for (var i = 0; i < colors.Length - 1; i++)
        for (var j = i + 1; j < colors.Length; j++)
          if (colors[i] != colors[j])
            max = Math.Max(max, j - i);

      return max;
    }
  }
}
