namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shortest-impossible-sequence-of-rolls/
///    Submission: https://leetcode.com/submissions/detail/755468744/
/// </summary>
internal class P2350
{
  public class Solution
  {
    public int ShortestSequence(int[] rolls, int k)
    {
      // greedy
      // find last index when all sequences if length L can be taken
      // for L = 1 it is when all k numbers are in the set
      // for L = 1 progress forward and find next k distinct elements

      var ans = 0;
      var set = new HashSet<int>();

      for (var i = 0; i < rolls.Length; i++)
      {
        set.Add(rolls[i]);

        if (set.Count == k)
        {
          ans++;
          set.Clear();
        }
      }

      return ans + 1;
    }
  }
}
