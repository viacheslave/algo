namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-words-obtained-after-adding-a-letter/
///    Submission: https://leetcode.com/submissions/detail/616398999/
/// </summary>
internal class P2135
{
  public class Solution
  {
    public int WordCount(string[] startWords, string[] targetWords)
    {
      var startMap = new HashSet<int>();

      foreach (var word in startWords)
      {
        var value = 0;
        foreach (var ch in word)
          value += 1 << (ch - 97);

        startMap.Add(value);
      }

      var ans = 0;

      foreach (var word in targetWords)
      {
        var value = 0;
        foreach (var ch in word)
          value += 1 << (ch - 97);

        for (var i = 0; i < 26; i++)
        {
          var bit = (1 << i);
          if ((value & bit) == bit)
          {
            var v = value - bit;
            if (startMap.Contains(v))
            {
              ans++;
              break;
            }
          }
        }
      }

      return ans;
    }
  }
}
