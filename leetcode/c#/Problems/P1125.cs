namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-sufficient-team/
///    Submission: https://leetcode.com/submissions/detail/422981358/
/// </summary>
internal class P1125
{
  public class Solution
  {
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
    {
      var skillMap = people
        .SelectMany(x => x).Distinct()
        .Select((s, i) => (s, i))
        .ToDictionary(x => x.s, x => x.i);

      var reqMask = GetMask(req_skills.ToList(), skillMap);

      var dp = new Dictionary<int, HashSet<int>>();
      dp[GetMask(people[0], skillMap)] = new HashSet<int> { 0 };

      for (var i = 1; i < people.Count; i++)
      {
        var mask = GetMask(people[i], skillMap);
        dp[mask] = new HashSet<int> { i };

        foreach (var m in dp.Keys.ToArray())
        {
          var totalmask = m | mask;

          if (!dp.ContainsKey(totalmask))
          {
            dp[totalmask] = dp[m].Concat(new int[] { i }).ToHashSet();
          }
          else
          {
            dp[totalmask] = (dp[totalmask].Count > dp[m].Count + 1)
              ? dp[m].Concat(new int[] { i }).ToHashSet()
              : dp[totalmask];
          }
        }
      }

      var ans = new List<HashSet<int>>();

      foreach (var entry in dp)
        if ((entry.Key & reqMask) == reqMask)
          ans.Add(entry.Value);

      var minCount = ans.Min(x => x.Count);
      return ans.First(a => a.Count == minCount).ToArray();
    }

    private int GetMask(IList<string> skills, Dictionary<string, int> skillMap)
    {
      var ans = 0;
      foreach (var skill in skills)
        ans += (int)Math.Pow(2, skillMap[skill]);

      return ans;
    }
  }
}
