namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-subarrays-with-fixed-bounds/
///    Submission: https://leetcode.com/problems/count-subarrays-with-fixed-bounds/submissions/828526973/
/// </summary>
internal class P2444
{
  public class Solution
  {
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
      var intervals = new List<(int start, int end)>();

      // calculate intervals in nums
      // where num is within min and max

      var start = -1;
      for (int i = 0; i < nums.Length; i++)
      {
        if (InBound(nums[i], minK, maxK) && (i == 0 || !InBound(nums[i - 1], minK, maxK)))
        {
          start = i;
          continue;
        }

        if (i > 0 && InBound(nums[i - 1], minK, maxK) && !InBound(nums[i], minK, maxK))
        {
          intervals.Add((start, i - 1));
          start = -1;
        }
      }

      if (start != -1 && InBound(nums[^1], minK, maxK))
      {
        intervals.Add((start, nums.Length - 1));
      }

      // filter intervals
      // where it has both min and max

      intervals = intervals
        .Where(iv =>
        {
          var hasMin = false;
          var hasMax = false;

          for (int i = iv.start; i <= iv.end; i++)
          {
            if (nums[i] == minK) hasMin = true;
            if (nums[i] == maxK) hasMax = true;
          }

          return hasMin && hasMax;
        })
        .ToList();

      var ans = 0L;

      if (minK == maxK)
      {
        return intervals
          .Sum(i =>
          {
            var length = i.end - i.start + 1;
            return 1L * length * (length + 1) / 2;
          });
      }

      foreach (var interval in intervals)
      {
        var exclude = 0L;
        var intervalLength = interval.end - interval.start + 1;
        var mins = new List<int>();
        var maxs = new List<int>();

        mins.Add(interval.start - 1);
        maxs.Add(interval.start - 1);

        for (int i = interval.start; i <= interval.end; i++)
        {
          if (nums[i] == minK) mins.Add(i);
          if (nums[i] == maxK) maxs.Add(i);
        }

        mins.Add(interval.end + 1);
        maxs.Add(interval.end + 1);

        // exclude every interval between mins
        for (int i = 1; i < mins.Count; i++)
        {
          var fromIndex = mins[i - 1];
          var toIndex = mins[i];

          var length = Math.Max(0, toIndex - fromIndex - 1);
          exclude += 1L * length * (length + 1) / 2;
        }

        // exclude every interval between maxs
        for (int i = 1; i < maxs.Count; i++)
        {
          var fromIndex = maxs[i - 1];
          var toIndex = maxs[i];

          var length = Math.Max(0, toIndex - fromIndex - 1);
          exclude += 1L * length * (length + 1) / 2;
        }


        // all interval that don't contain mins or maxs
        // are counted twice
        // remove them
        var extrema = mins.Concat(maxs).Distinct().OrderBy(x => x).ToList();

        for (int i = 1; i < extrema.Count; i++)
        {
          var fromIndex = extrema[i - 1];
          var toIndex = extrema[i];

          var length = Math.Max(0, toIndex - fromIndex - 1);
          exclude -= 1L * length * (length + 1) / 2;
        }

        ans += 1L * intervalLength * (intervalLength + 1) / 2 - exclude;
      }

      return ans;
    }

    private static bool InBound(int num, int minK, int maxK)
    {
      return num >= minK && num <= maxK;
    }
  }

}
