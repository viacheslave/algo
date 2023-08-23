namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i/
///    Submission: https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i/submissions/911461917/
/// </summary>
internal class P2554
{
  public class Solution
  {
    public int MaxCount(int[] banned, int n, int maxSum)
    {
      banned = banned.Distinct().ToArray();
      Array.Sort(banned);

      var prefixSum = new int[banned.Length + 1];
      for (var i = 0; i < banned.Length; i++)
      {
        prefixSum[i + 1] = prefixSum[i] + banned[i];
      }

      // binary search
      int lo = 0;
      int hi = n;

      while (lo < hi)
      {
        var mid = (lo + hi) >> 1;
        var sum = GetSum(banned, mid, prefixSum);

        if (hi - lo == 1)
        {
          if (GetSum(banned, hi, prefixSum) <= maxSum)
            lo = hi;

          break;
        }

        if (sum > maxSum)
        {
          hi = mid - 1;
        }
        else
        {
          lo = mid;
        }
      }

      var s = GetSum(banned, lo, prefixSum);
      if (s <= maxSum)
      {
        var bannedIndex = GetLastBannedIndex(banned, lo);
        return lo - (bannedIndex + 1);
      }

      return 0;
    }

    private int GetSum(int[] banned, int mid, int[] prefixSum)
    {
      var index = GetLastBannedIndex(banned, mid);
      var bannedSum = index == -1 ? 0 : prefixSum[index + 1];

      return (mid * (mid + 1) / 2) - bannedSum;
    }

    private int GetLastBannedIndex(int[] banned, long mid)
    {
      if (mid < banned[0])
        return -1;

      int lo = 0, hi = banned.Length - 1;
      while (lo < hi)
      {
        var index = (lo + hi) >> 1;

        if (hi - lo == 1)
        {
          if (banned[hi] <= mid)
            lo = hi;

          break;
        }

        if (banned[index] > mid)
        {
          hi = index - 1;
        }
        else
        {
          lo = index;
        }
      }

      return lo;
    }
  }
}
