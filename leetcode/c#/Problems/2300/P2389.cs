namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-subsequence-with-limited-sum/
///    Submission: https://leetcode.com/submissions/detail/788131478/
/// </summary>
internal class P2389
{
  public class Solution
  {
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
      // greedy
      // binary search

      Array.Sort(nums);

      var prefixSums = new int[nums.Length];
      prefixSums[0] = nums[0];

      for (int i = 1; i < prefixSums.Length; i++)
      {
        prefixSums[i] = prefixSums[i - 1] + nums[i];
      }

      var ans = new int[queries.Length];

      for (int i = 0; i < queries.Length; i++)
      {
        var size = BinarySearch(prefixSums, queries[i]);
        ans[i] = size;
      }

      return ans;
    }

    private int BinarySearch(int[] prefixSums, int v)
    {
      int min = 0, max = prefixSums.Length - 1;

      while (true)
      {
        if (max - min <= 1)
        {
          if (prefixSums[max] <= v)
            return max + 1;
          if (prefixSums[min] <= v)
            return min + 1;
          return 0;
        }

        var mid = (min + max) >> 1;
        if (prefixSums[mid] <= v)
        {
          min = mid;
        }
        else
        {
          max = mid;
        }
      }
    }
  }
}
