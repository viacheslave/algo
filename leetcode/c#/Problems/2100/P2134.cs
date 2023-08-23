namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii/
///    Submission: https://leetcode.com/submissions/detail/616213453/
/// </summary>
internal class P2134
{
  public class Solution
  {
    public int MinSwaps(int[] nums)
    {
      var n = nums.Length;

      var oc = nums.Count(x => x == 1);
      var oz = n - oc;

      var prefixZeros = new int[n + 1];

      for (var i = 0; i < n; i++)
      {
        prefixZeros[i + 1] = nums[i] == 0
          ? prefixZeros[i] + 1
          : prefixZeros[i];
      }

      var plainArray = int.MaxValue;

      for (var i = 0; i < n - oc + 1; i++)
      {
        var zeros = prefixZeros[i + oc] - prefixZeros[i];
        plainArray = Math.Min(plainArray, zeros);
      }

      var circularArray = int.MaxValue;

      for (var i = 0; i <= oc; i++)
      {
        var before = prefixZeros[i] - prefixZeros[0];
        var after = prefixZeros[n] - prefixZeros[n - oc + i];

        circularArray = Math.Min(circularArray, before + after);
      }

      return Math.Min(plainArray, circularArray);
    }
  }

}
