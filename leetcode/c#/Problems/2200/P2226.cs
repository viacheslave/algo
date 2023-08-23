namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-candies-allocated-to-k-children/
///    Submission: https://leetcode.com/submissions/detail/675183347/
/// </summary>
internal class P2226
{
  public class Solution
  {
    public int MaximumCandies(int[] candies, long k)
    {
      var arr = candies.OrderByDescending(x => x).ToArray();
      var sum = arr.Select(a => (long)a).Sum();

      if (sum < k)
        return 0;

      // binary search
      var min = 1;
      var max = arr[0];

      while (true)
      {
        if (max - min <= 1)
        {
          var maxPeople = GetPeople(arr, max);
          if (maxPeople >= k)
            return max;
          return min;
        }

        var mid = (max + min) >> 1;
        var midPeople = GetPeople(arr, mid);

        if (midPeople >= k)
          min = mid;
        else
          max = mid;
      }
    }

    private long GetPeople(int[] arr, int candies)
    {
      var ans = 0L;

      foreach (var a in arr)
      {
        ans += a / candies;
      }

      return ans;
    }
  }
}
