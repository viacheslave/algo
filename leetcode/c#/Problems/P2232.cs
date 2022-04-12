namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimize-result-by-adding-parentheses-to-expression/
///    Submission: https://leetcode.com/submissions/detail/677575363/
/// </summary>
internal class P2232
{
  public class Solution
  {
    public string MinimizeResult(string expression)
    {
      var plus = expression.IndexOf('+');

      var ans = int.MaxValue;
      var ansExpression = "";

      // check all options

      for (var l = 0; l <= plus - 1; l++)
      {
        for (int r = plus + 1; r <= expression.Length - 1; r++)
        {
          // before l
          // after r

          var left = expression[..l];
          var right = expression[(r + 1)..];

          if (left?.Length == 0) left = "1";
          if (right?.Length == 0) right = "1";

          var mid = expression.Substring(l, r - l + 1);

          var ps = mid.Split('+');

          var res = int.Parse(left) * int.Parse(right) *
            (int.Parse(ps[0]) + int.Parse(ps[1]));

          if (res < ans)
          {
            ans = Math.Min(ans, res);

            var sb = new StringBuilder(expression);
            sb.Insert(l, '(');
            sb.Insert(r + 1 + 1, ')');

            ansExpression = sb.ToString();
          }
        }
      }

      return ansExpression;
    }
  }
}
