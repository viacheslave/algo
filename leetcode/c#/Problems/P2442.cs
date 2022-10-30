namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-number-of-distinct-integers-after-reverse-operations/
///    Submission: https://leetcode.com/problems/count-number-of-distinct-integers-after-reverse-operations/submissions/823857953/
/// </summary>
internal class P2442
{
  public class Solution
  {
    public int CountDistinctIntegers(int[] nums)
    {
      var set = nums.ToHashSet();

      foreach (var num in nums)
      {
        set.Add(GetReversed(num));
      }

      return set.Count;
    }

    public static int GetReversed(int num)
    {
      var rn = 0;

      while (num > 0)
      {
        var div = num / 10;
        var mod = num % 10;
        rn = rn * 10 + mod;

        num = div;
      }

      return rn;
    }
  }
}
