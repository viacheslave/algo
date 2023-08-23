namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/split-message-based-on-limit/
///    Submission: https://leetcode.com/problems/split-message-based-on-limit/submissions/842552716/
/// </summary>
internal class P2468
{
  public class Solution
  {
    public string[] SplitMessage(string message, int limit)
    {
      // binary search

      var lo = 1;
      var hi = message.Length;

      while (lo < hi)
      {
        var length = (lo + hi) >> 1;
        var (arr, pointer) = Build(message, limit, length);

        if (pointer < message.Length)
        {
          lo = length + 1;
        }
        else
        {
          hi = length;
        }
      }

      // build
      var res = Build(message, limit, lo);

      if (res.arr.Length == lo && res.pointer == message.Length)
        return res.arr;

      return Array.Empty<string>();
    }

    private static (string[] arr, int pointer) Build(string message, int limit, int lo)
    {
      var list = new List<string>();
      var pointer = 0;

      for (var i = 1; i <= lo; i++)
      {
        var suffix = $"<{i}/{lo}>";

        var length = Math.Min(limit - suffix.Length, message.Length - pointer);
        if (length <= 0)
          break;

        list.Add(string.Concat(message.AsSpan(pointer, length), suffix));

        pointer += length;
      }

      var arr = list.ToArray();
      return (arr, pointer);
    }
  }

}
