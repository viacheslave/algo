namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-even-numbers-after-queries/
///    Submission: https://leetcode.com/submissions/detail/234752245/
/// </summary>
internal class P0985
{
  public class Solution
  {
    public int[] SumEvenAfterQueries(int[] A, int[][] queries)
    {
      var res = new List<int>(queries.Length);

      var evenSum = A.Where(_ => _ % 2 == 0).Sum();

      foreach (var query in queries)
      {
        var val = query[0];
        var index = query[1];

        var current = A[index];
        var updated = current + val;

        if (updated % 2 == 0)
        {
          if (current % 2 == 0)
            evenSum += val;
          else
            evenSum += updated;

        }
        else
        {
          if (current % 2 == 0)
            evenSum -= current;
        }

        A[index] = updated;
        res.Add(evenSum);
      }


      return res.ToArray();
    }
  }
}
