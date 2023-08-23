namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-value-of-the-rearranged-number/
///    Submission: https://leetcode.com/submissions/detail/635645764/
/// </summary>
internal class P2165
{
  public class Solution
  {
    public long SmallestNumber(long num)
    {
      if (num == 0)
      {
        return 0;
      }

      var digits = Math.Abs(num)
        .ToString()
        .Select(x => int.Parse(x.ToString())).ToArray();

      if (num < 0)
      {
        return -long.Parse(
          new string(digits.OrderByDescending(x => x).Select(x => char.Parse(x.ToString())).ToArray()));
      }
      else
      {
        var zeroes = digits.Count(x => x == 0);
        digits = digits.Where(x => x != 0).OrderBy(x => x).ToArray();

        var ans = new List<int>();
        ans.Add(digits[0]);

        if (zeroes > 0)
        {
          ans.AddRange(Enumerable.Repeat(0, zeroes));
        }

        ans.AddRange(digits.Skip(1));
        return long.Parse(
          new string(ans.Select(x => char.Parse(x.ToString())).ToArray()));
      }
    }
  }

}
