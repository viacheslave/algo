namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximize-score-after-n-operations/
///    Submission: https://leetcode.com/submissions/detail/573852923/
/// </summary>
internal class P1799
{
  public class Solution
  {
    private int _max = int.MinValue;

    public int MaxScore(int[] nums)
    {
      var mask = new int[nums.Length];
      var dp = new Dictionary<(int, int), int>();

      Recursive(nums, mask, dp, new List<int>(), nums.Length);

      return _max;
    }

    private void Recursive(int[] nums, int[] mask, Dictionary<(int, int), int> dp, List<int> gcdSum, int available)
    {
      if (available == 0)
      {
        var sorted = gcdSum.OrderBy(x => x).ToList();

        var ans = 0;
        for (var i = 1; i <= gcdSum.Count; i++)
        {
          ans += i * sorted[i - 1];
        }

        _max = Math.Max(_max, ans);
        return;
      }

      var s = -1;
      var e = -1;

      for (var i = 0; i < nums.Length; i++)
      {
        if (mask[i] == 1)
          continue;

        if (s == -1)
        {
          s = i;
          mask[s] = 1;
          continue;
        }

        if (e == -1)
        {
          e = i;

          var gcd = dp.ContainsKey((s, e)) ? dp[(s, e)] : GetGcd(nums[s], nums[e]);
          dp[(s, e)] = gcd;

          gcdSum.Add(gcd);

          mask[e] = 1;
          Recursive(nums, mask, dp, gcdSum, available - 2);
          mask[e] = 0;

          gcdSum.RemoveAt(gcdSum.Count - 1);

          e = -1;
        }
      }

      mask[s] = 0;
    }

    private int GetGcd(int a, int b)
    {
      if (a == b)
        return a;

      if (a > b)
        return GetGcd(a - b, b);
      else
        return GetGcd(a, b - a);
    }
  }
}
