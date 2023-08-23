namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sender-with-largest-word-count/
///    Submission: https://leetcode.com/submissions/detail/712070369/
/// </summary>
internal class P2284
{
  public class Solution
  {
    public string LargestWordCount(string[] messages, string[] senders)
    {
      return Enumerable.Range(0, senders.Length)
        .Select(x => (senders[x], messages[x]))
        .GroupBy(x => x.Item1)
        .ToDictionary(x => x.Key, x => x.Sum(s => s.Item2.Split(' ').Length))
        .OrderByDescending(x => x.Value)
        .ThenByDescending(x => x.Key, StringComparer.Ordinal)
        .First()
        .Key;
    }
  }
}
