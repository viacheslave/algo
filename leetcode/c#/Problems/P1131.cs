namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-of-absolute-value-expression/
///    Submission: https://leetcode.com/submissions/detail/585134508/
/// </summary>
internal class P1131
{
  public class Solution
  {
    public int MaxAbsValExpr(int[] arr1, int[] arr2)
    {
      // |arr1[i] - arr1[j]| + |arr2[i] - arr2[j]| + |i - j|

      var ans = int.MinValue;
      var length = arr1.Length;

      // case 1
      // (arr1[i] + arr2[i] + i) + (- arr1[j] - arr2[j] - j)
      ans = Math.Max(ans, Max(
        length,
        i => arr1[i] + arr2[i] + i,
        i => -arr1[i] - arr2[i] - i));

      // case 2
      // (arr1[i] + arr2[i] - i) + (- arr1[j] - arr2[j] + j)
      ans = Math.Max(ans, Max(
        length,
        i => arr1[i] + arr2[i] - i,
        i => -arr1[i] - arr2[i] + i));

      // case 3
      // (arr1[i] - arr2[i] + i) + (- arr1[j] + arr2[j] - j)
      ans = Math.Max(ans, Max(
        length,
        i => arr1[i] - arr2[i] + i,
        i => -arr1[i] + arr2[i] - i));

      // case 4
      // (arr1[i] - arr2[i] - i) + (- arr1[j] + arr2[j] + j)
      ans = Math.Max(ans, Max(
        length,
        i => arr1[i] - arr2[i] - i,
        i => -arr1[i] + arr2[i] + i));

      // case 5
      // (- arr1[i] + arr2[i] + i) + (+ arr1[j] - arr2[j] - j)
      ans = Math.Max(ans, Max(
        length,
        i => -arr1[i] + arr2[i] + i,
        i => +arr1[i] - arr2[i] - i));

      // case 6
      // (- arr1[i] + arr2[i] - i) + (+ arr1[j] - arr2[j] + j)
      ans = Math.Max(ans, Max(
        length,
        i => -arr1[i] + arr2[i] - i,
        i => +arr1[i] - arr2[i] + i));

      // case 7
      // (- arr1[i] - arr2[i] + i) + (+ arr1[j] + arr2[j] - j)
      ans = Math.Max(ans, Max(
        length,
        i => -arr1[i] - arr2[i] + i,
        i => +arr1[i] + arr2[i] - i));

      // case 8
      // (- arr1[i] - arr2[i] - i) + (+ arr1[j] + arr2[j] + j)
      ans = Math.Max(ans, Max(
        length,
        i => -arr1[i] - arr2[i] - i,
        i => +arr1[i] + arr2[i] + i));

      return ans;
    }

    public int Max(int length, Func<int, int> left, Func<int, int> right)
    {
      var x = new int[length];
      var y = new int[length];

      for (var i = 0; i < length; i++)
      {
        x[i] = left(i);
        y[i] = right(i);
      }

      Array.Sort(x);
      Array.Sort(y);

      return x[length - 1] + y[length - 1];
    }
  }
}
