using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-original-array-of-prefix-xor/
///    Submission: https://leetcode.com/problems/find-the-original-array-of-prefix-xor/submissions/818599091/
/// </summary>
internal class P2433
{
  public class Solution
  {
    public int[] FindArray(int[] pref)
    {
      var ans = new int[pref.Length];
      ans[0] = pref[0];

      var running = ans[0];

      for (int i = 1; i < pref.Length; i++)
      {
        ans[i] = running ^ pref[i];
        running = running ^ ans[i];
      }

      return ans;
    }
  }
}
