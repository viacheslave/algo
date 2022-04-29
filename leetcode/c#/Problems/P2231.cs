namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-number-after-digit-swaps-by-parity/
///    Submission: https://leetcode.com/submissions/detail/689661436/
/// </summary>
internal class P2231
{
  public class Solution
  {
    public int LargestInteger(int num)
    {
      var even = num.ToString()
        .Select((x, i) => (x, i))
        .Select(x => (x: int.Parse(x.x.ToString()), i: x.i))
        .Where(x => x.x % 2 == 0)
        .ToArray();

      var odd = num.ToString()
        .Select((x, i) => (x, i))
        .Select(x => (x: int.Parse(x.x.ToString()), i: x.i))
        .Where(x => x.x % 2 != 0)
        .ToArray();

      even = even.OrderByDescending(x => x.x).ToArray();
      odd = odd.OrderByDescending(x => x.x).ToArray();

      var evenIndices = even.Select(x => x.i).OrderBy(x => x).ToArray();
      var oddIndices = odd.Select(x => x.i).OrderBy(x => x).ToArray();

      var res = new int[num.ToString().Length];

      for (var index = 0; index < even.Length; index++)
        res[evenIndices[index]] = even[index].x;

      for (var index = 0; index < odd.Length; index++)
        res[oddIndices[index]] = odd[index].x;

      return int.Parse(string.Join("", res));
    }
  }
}
