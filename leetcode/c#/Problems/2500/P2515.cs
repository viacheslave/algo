namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array/
///    Submission: https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array/submissions/865377669/
/// </summary>
internal class P2515
{
  public class Solution
  {
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
      var indices = new List<int>();

      for (var i = 0; i < words.Length; i++)
      {
        var word = words[i];
        if (target == word)
          indices.Add(i);
      }

      if (indices.Count == 0)
      {
        return -1;
      }

      var ans = int.MaxValue;

      foreach (var index in indices)
      {
        ans = Math.Min(ans,
          Math.Min(
            Math.Abs(startIndex - index),
            words.Length - Math.Abs(startIndex - index)));
      }

      return ans;
    }
  }
}
