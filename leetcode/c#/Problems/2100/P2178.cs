namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-split-of-positive-even-integers/
///    Submission: https://leetcode.com/submissions/detail/644570154/
/// </summary>
internal class P2178
{
  public class Solution
  {
    public IList<long> MaximumEvenSplit(long finalSum)
    {
      if (finalSum % 2 == 1)
      {
        return new List<long>();
      }

      var ans = new List<long>();
      var current = 0;

      while (true)
      {
        current += 2;

        if (finalSum - current == 0)
        {
          ans.Add(current);
          break;
        }

        if (finalSum - current < current + 2)
        {
          ans.Add(finalSum);
          break;
        }

        finalSum -= current;
        ans.Add(current);
      }

      return ans;
    }
  }
}
