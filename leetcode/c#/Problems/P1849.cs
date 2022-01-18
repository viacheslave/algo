namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/splitting-a-string-into-descending-consecutive-values/
///    Submission: https://leetcode.com/submissions/detail/588188647/
/// </summary>
internal class P1849
{
  public class Solution
  {
    public bool SplitString(string s)
    {
      var span = s.AsSpan();

      for (var i = 0; i < s.Length - 1; i++)
      {
        try
        {
          var cur = long.Parse(span.Slice(0, i + 1));
          var start = i + 1;

          // case: "1000" -> "1", "000"
          if (cur == 1 && int.Parse(span.Slice(start, s.Length - start)) == 0)
            return true;

          for (var j = start; j < s.Length; j++)
          {
            var slice = span.Slice(start, j - start + 1);

            var next = long.Parse(slice);
            if (cur == next + 1)
            {
              cur = next;
              start = j + 1;

              // last number ends with last char
              if (j == s.Length - 1)
                return true;

              // case: "200100" -> "1", "000"
              if (cur == 1 && int.Parse(span.Slice(start, s.Length - start)) == 0)
                return true;
            }
          }
        }
        catch (OverflowException ex)
        {
          continue;
        }
      }

      return false;
    }
  }
}
