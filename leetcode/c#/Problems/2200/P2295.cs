namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/replace-elements-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/714802250/
/// </summary>
internal class P2295
{
  public class Solution
  {
    public int[] ArrayChange(int[] nums, int[][] operations)
    {
      var map = new Dictionary<int, int>();

      for (var i = 0; i < nums.Length; i++)
      {
        map[nums[i]] = i;
      }

      foreach (var op in operations)
      {
        var index = map[op[0]];

        map.Remove(op[0]);
        map[op[1]] = index;
      }

      var a = new int[nums.Length];

      foreach (var kvp in map)
      {
        a[kvp.Value] = kvp.Key;
      }

      return a;
    }
  }
}
