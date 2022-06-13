namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-subarrays-with-score-less-than-k/
///    Submission: https://leetcode.com/submissions/detail/720489094/
/// </summary>
internal class P2302
{
  public class Solution
  {
    public long CountSubarrays(int[] nums, long k)
    {
      var prefixSums = new long[nums.Length + 1];

      for (int i = 0; i < nums.Length; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + nums[i];
      }

      // two pointers

      var l = 0;
      var r = 0;
      var ans = 0L;
      (int, int)? last = default;

      while (r < nums.Length)
      {
        var score = GetScore(prefixSums, l, r);
        if (l == r && score >= k)
        {
          l++;
          r++;
          continue;
        }

        // expand r to the right
        while (r + 1 < nums.Length && GetScore(prefixSums, l, r + 1) < k)
        {
          r++;
        }

        var length = r - l + 1;
        ans += 1L * length * (length + 1) / 2;

        if (last is not null)
        {
          // subtract the intersection
          if (last.Value.Item2 >= l)
          {
            var sub = (r: last.Value.Item2, l: l);
            length = sub.r - sub.l + 1;
            ans -= 1L * length * (length + 1) / 2;
          }
        }

        last = (l, r);

        // move
        l++;
        if (l > r)
        {
          r++;
        }
      }

      return ans;

      static long GetScore(long[] prefixSums, int l, int r)
      {
        return (r - l + 1) * (prefixSums[r + 1] - prefixSums[l]);
      }
    }
  }
}
