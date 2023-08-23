namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/decremental-string-concatenation/
///    Submission: https://leetcode.com/problems/decremental-string-concatenation/submissions/990165829/
/// </summary>
internal class P2746
{
  public class Solution
  {
    public int MinimizeConcatenatedLength(string[] words)
    {
      // dp
      var dp = new Dictionary<string, int>
      {
        [$"{words[0][0]}{words[0][^1]}"] = words[0].Length
      };

      for (var i = 1; i < words.Length; i++)
      {
        var next = new Dictionary<string, int>();

        foreach (var item in dp)
        {
          var key = $"{item.Key[0]}{words[i][^1]}";

          next[key] = Math.Min(
            next.GetValueOrDefault(key, int.MaxValue),
            item.Key[1] == words[i][0] ? item.Value + words[i].Length - 1 : item.Value + words[i].Length);

          key = $"{words[i][0]}{item.Key[^1]}";

          next[key] = Math.Min(
            next.GetValueOrDefault(key, int.MaxValue),
            words[i][^1] == item.Key[0] ? item.Value + words[i].Length - 1 : item.Value + words[i].Length);
        }

        dp = next;
      }

      return dp.Values.Min();
    }
  }
}
