namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-buckets-required-to-collect-rainwater-from-houses/
///    Submission: https://leetcode.com/submissions/detail/593896074/
/// </summary>
internal class P2086
{
  public class Solution
  {
    public int MinimumBuckets(string street)
    {
      // check impossible cases
      // 'HH
      // HH'
      // ..HHH..
      if (street.Length >= 2)
      {
        if (street[0] == 'H' && street[1] == 'H')
          return -1;

        if (street[^2] == 'H' && street[^1] == 'H')
          return -1;

        if (street.Length >= 3)
          for (var i = 0; i < street.Length - 3; i++)
            if (street[i] == 'H' && street[i + 1] == 'H' && street[i + 2] == 'H')
              return -1;
      }

      var middles = 0;
      var extra = 0;

      var sb = new StringBuilder(street);

      // Greedy
      // it is optimal first to fill cases 'H.H'
      for (var i = 1; i < street.Length - 1; i++)
      {
        if (sb[i] == '.' && sb[i - 1] == 'H' && sb[i + 1] == 'H')
        {
          sb[i - 1] = '.';
          sb[i + 1] = '.';
          middles++;
        }
      }

      // then add one bucket for building
      for (var i = 0; i < sb.Length; i++)
        if (sb[i] == 'H')
          extra++;

      if (extra > sb.Length / 2)
        return -1;

      return extra + middles;
    }
  }
}
