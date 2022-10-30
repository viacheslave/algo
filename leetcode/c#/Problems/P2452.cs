namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/words-within-two-edits-of-dictionary/
///    Submission: https://leetcode.com/problems/words-within-two-edits-of-dictionary/submissions/833200596/
/// </summary>
internal class P2452
{
  public class Solution
  {
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
      // brute force

      var ans = new List<string>();

      foreach (var query in queries)
      {
        foreach (var dict in dictionary)
        {
          var diffCount = 0;

          for (int i = 0; i < query.Length; i++)
          {
            if (query[i] != dict[i])
            {
              diffCount++;
              if (diffCount > 2) break;
            }
          }

          if (diffCount <= 2)
          {
            ans.Add(query);
            break;
          }
        }
      }

      return ans;
    }
  }
}
