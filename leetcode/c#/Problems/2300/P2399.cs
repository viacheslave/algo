namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-distances-between-same-letters/
///    Submission: https://leetcode.com/submissions/detail/793954413/
/// </summary>
internal class P2399
{
  public class Solution
  {
    public bool CheckDistances(string s, int[] distance)
    {
      var dict = s.Select((c, i) => (c, i))
        .GroupBy(x => x.c)
        .ToDictionary(x => x.Key, x =>
        {
          var items = x.Select(f => f.i).OrderByDescending(f => f).ToArray();
          return items[0] - items[1] - 1;
        });

      for (var i = 0; i < distance.Length; i++)
      {
        var ch = (char)(97 + i);
        if (dict.ContainsKey(ch))
        {
          if (dict[ch] != distance[i])
          {
            return false;
          }
        }
      }

      return true;
    }
  }
}
