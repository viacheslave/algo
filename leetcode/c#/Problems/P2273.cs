namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/
///    Submission: https://leetcode.com/submissions/detail/699955867/
/// </summary>
internal class P2273
{
  public class Solution
  {
    public IList<string> RemoveAnagrams(string[] words)
    {
      var sorted = words
        .Select(w => new string(w.OrderBy(c => c).ToArray()))
        .ToArray();

      var ans = new List<int>();

      for (var i = 0; i < words.Length; i++)
      {
        if (ans.Count == 0 || sorted[i] != sorted[ans[^1]])
        {
          ans.Add(i);
        }
      }

      return ans.Select(i => words[i]).ToList();
    }
  }
}
