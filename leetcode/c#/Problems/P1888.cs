namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/
///    Submission: https://leetcode.com/submissions/detail/590010170/
/// </summary>
internal class P1888
{
  public class Solution
  {
    public int MinFlips(string s)
    {
      var elements = s.Select((x, i) => (x, i));
      int oddOnes = elements.Count(x => x.x == '1' && x.i % 2 == 1);
      int evenOnes = elements.Count(x => x.x == '1' && x.i % 2 == 0);

      // if s.length is even than
      // it doesn't make sense to cycle the chars
      if (s.Length % 2 == 0)
      {
        var len = s.Length / 2;
        return GetSteps(len, oddOnes, len, evenOnes);
      }

      var evenLength = s.Length / 2 + 1;
      var oddLength = s.Length / 2;

      var index = 0;
      var ans = GetSteps(oddLength, oddOnes, evenLength, evenOnes);

      // try cycle chars and check
      // if new configuration is better than previous
      while (index < s.Length)
      {
        var tmpOddOnes = evenOnes;
        var tmpEvenOnes = oddOnes;

        if (s[index] == '1')
        {
          tmpEvenOnes++;
          tmpOddOnes--;
        }

        var tmpSteps = GetSteps(oddLength, tmpOddOnes, evenLength, tmpEvenOnes);

        ans = Math.Min(ans, tmpSteps);

        evenOnes = tmpEvenOnes;
        oddOnes = tmpOddOnes;

        index++;
      }

      return ans;
    }

    public int GetSteps(int oddLength, int oddOnes, int evenLength, int evenOnes)
    {
      // get min of:
      // odds to ones, evens to zeros vs.
      // odds to zeros, evens to ones

      return Math.Min(
        (oddLength - oddOnes) + evenOnes,
        (evenLength - evenOnes) + oddOnes);
    }
  }
}
