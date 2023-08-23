namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/rearrange-characters-to-make-target-string/
///    Submission: https://leetcode.com/submissions/detail/712028790/
/// </summary>
internal class P2287
{
  public class Solution
  {
    public int RearrangeCharacters(string s, string target)
    {
      var sourceMap = s.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
      var targetMap = target.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

      var max = int.MaxValue;

      foreach (var letter in targetMap.Keys)
      {
        if (!sourceMap.ContainsKey(letter))
          return 0;

        max = Math.Min(max, sourceMap[letter] / targetMap[letter]);
      }

      return max;
    }
  }
}
