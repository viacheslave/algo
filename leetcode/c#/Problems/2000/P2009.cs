namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-make-array-continuous
///    Submission: https://leetcode.com/problems/minimum-number-of-operations-to-make-array-continuous/submissions/838104830/
/// </summary>
internal class P2009
{
  public class Solution
  {
    public int MinOperations(int[] nums)
    {
      // first replace duplicates with some negative values
      // these negative values will not participate in calculations

      var set = new HashSet<int>();
      var negative = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        if (set.Contains(nums[i]))
        {
          nums[i] = negative--;
          continue;
        }

        set.Add(nums[i]);
      }

      // sort the nums
      Array.Sort(nums);

      var ans = int.MaxValue;

      for (int i = 0; i < nums.Length; i++)
      {
        // skip negatives
        if (nums[i] <= 0)
          continue;

        var start = nums[i];
        var end = start + nums.Length - 1;

        // try find the right end
        // then all nums between start and bisect are considered in their places
        // so they should not be changed to other numbers
        var bisect = Bisect(nums, end);

        var correctPlaces = set.Contains(end) ? bisect - i + 1 : bisect - i;
        ans = Math.Min(ans, nums.Length - correctPlaces);
      }

      return ans;
    }

    private int Bisect(int[] a, int x)
    {
      var lo = 0;
      var hi = a.Length;

      while (lo < hi)
      {
        var mid = (lo + hi) >> 1;
        if (a[mid] < x)
          lo = mid + 1;
        else
          hi = mid;
      }

      return lo;
    }
  }
}
