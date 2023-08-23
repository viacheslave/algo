using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/different-ways-to-add-parentheses/
///    Submission: https://leetcode.com/submissions/detail/636533852/
/// </summary>
internal class P0241
{
  public class Solution
  {
    public IList<int> DiffWaysToCompute(string expression)
    {
      var opsActions = new Dictionary<char, Func<int, int, int>>
      {
        ['+'] = (a, b) => a + b,
        ['-'] = (a, b) => a - b,
        ['*'] = (a, b) => a * b,
      };

      var nodes = expression.Split(opsActions.Keys.ToArray())
        .Select(x => int.Parse(x))
        .ToList();

      if (nodes.Count == 1)
        return new List<int> { nodes[0] };

      var opsPositions = new List<char>();

      for (var i = 0; i < expression.Length; i++)
      {
        if (opsActions.ContainsKey(expression[i]))
          opsPositions.Add(expression[i]);
      }

      var dp = new Dictionary<(int from, int to), List<int>>();

      for (var span = 0; span < nodes.Count; span++)
      {
        for (var index = 0; index < nodes.Count - span; index++)
        {
          if (span == 0)
          {
            dp[(index, index)] = new List<int> { nodes[index] };
            continue;
          }

          var start = index;
          var end = index + span;

          var value = new List<int>();

          for (var k = start; k < end; k++)
          {
            var left = dp[(start, k)];
            var right = dp[(k + 1, end)];

            foreach (var a in left)
            {
              foreach (var b in right)
              {
                var op = opsPositions[k];
                var func = opsActions[op];

                value.Add(func(a, b));
              }
            }
          }

          dp[(start, end)] = value.ToList();
        }
      }

      return dp[(0, nodes.Count - 1)];
    }
  }

}
