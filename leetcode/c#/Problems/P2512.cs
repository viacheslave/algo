namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reward-top-k-students/
///    Submission: https://leetcode.com/problems/reward-top-k-students/submissions/865687745/
/// </summary>
internal class P2512
{
  public class Solution
  {
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
    {
      var positiveMap = positive_feedback.ToHashSet();
      var negativeMap = negative_feedback.ToHashSet();

      var points = new Dictionary<int, int>();

      for (int i = 0; i < student_id.Length; i++)
      {
        var id = student_id[i];
        var rep = report[i];

        points[id] = 0;

        var tokens = rep.Split(' ', StringSplitOptions.RemoveEmptyEntries)
          .GroupBy(r => r)
          .ToDictionary(r => r.Key, r => r.Count());

        var tokenMap = tokens.Keys.ToHashSet();

        foreach (var t in tokenMap)
        {
          if (positiveMap.Contains(t))
            points[id] += 3 * tokens[t];

          if (negativeMap.Contains(t))
            points[id] -= tokens[t];
        }
      }

      return points.OrderByDescending(p => p.Value)
        .ThenBy(p => p.Key)
        .Take(k)
        .Select(o => o.Key)
        .ToList();
    }
  }
}
