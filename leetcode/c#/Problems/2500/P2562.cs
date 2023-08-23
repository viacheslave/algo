namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-array-concatenation-value/
///    Submission: https://leetcode.com/problems/find-the-array-concatenation-value/submissions/900934741/
/// </summary>
internal class P2562
{
  public class Solution
  {
    public long FindTheArrayConcVal(int[] nums)
    {
      var ans = 0L;

      var lo = 0;
      var hi = nums.Length - 1;

      while (lo <= hi)
      {
        if (lo != hi)
        {
          ans += int.Parse($"{nums[lo]}{nums[hi]}");
        }
        else
        {
          ans += nums[lo];
        }

        lo++;
        hi--;
      }

      return ans;
    }
  }
}
