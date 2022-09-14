namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/optimal-partition-of-string/
///    Submission: https://leetcode.com/submissions/detail/797394161/
/// </summary>
internal class P2405
{
  public class Solution
  {
    public int PartitionString(string s)
    {
      // greedy

      var ans = 0;

      var set = new HashSet<char>();

      foreach (var ch in s)
      {
        if (!set.Contains(ch))
        {
          set.Add(ch);
          continue;
        }

        ans++;
        set.Clear();
        set.Add(ch);
      }

      return ans + 1;
    }
  }
}
