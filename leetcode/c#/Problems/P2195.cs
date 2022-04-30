namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/append-k-integers-with-minimal-sum/
///    Submission: https://leetcode.com/submissions/detail/690391645/
/// </summary>
internal class P2195
{
  public class Solution
  {
    public long MinimalKSum(int[] nums, int k)
    {
      var map = new SortedDictionary<int, int>(
        nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()));

      var numKeys = map.Keys.ToList();

      var last = 1L * k;

      for (var i = 0; i < numKeys.Count; i++)
      {
        var num = numKeys[i];
        if (num <= last)
        {
          last++;
        }
      }

      var ans = last * (last + 1) / 2;

      foreach (var kvp in map)
      {
        if (kvp.Key > last)
        {
          break;
        }

        ans -= kvp.Key;
      }

      return ans;
    }
  }
}
