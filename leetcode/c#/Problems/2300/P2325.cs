namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/decode-the-message/
///    Submission: https://leetcode.com/submissions/detail/737450868/
/// </summary>
internal class P2325
{
  public class Solution
  {
    public string DecodeMessage(string key, string message)
    {
      var map = new Dictionary<char, char>();

      foreach (var ch in key)
      {
        if (map.ContainsKey(ch) || ch == ' ')
          continue;

        map[ch] = (char)(97 + map.Count);
      }

      var sb = new StringBuilder();

      foreach (var ch in message)
      {
        if (ch == ' ')
        {
          sb.Append(' ');
        }
        else
        {
          sb.Append(map[ch]);
        }
      }

      return sb.ToString();
    }
  }
}
