namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/average-value-of-even-numbers-that-are-divisible-by-three/
///    Submission: https://leetcode.com/problems/average-value-of-even-numbers-that-are-divisible-by-three/submissions/833305406/
/// </summary>
internal class P2455
{
  public class Solution
  {
    public int AverageValue(int[] nums)
    {
      var items = nums.Where(n => n % 6 == 0).ToArray();
      if (items.Length == 0)
      {
        return 0;
      }

      return (int)Math.Floor(1f * items.Sum() / items.Length);
    }
  }
}
