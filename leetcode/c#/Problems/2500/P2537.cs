namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-the-number-of-good-subarrays/
///    Submission: https://leetcode.com/problems/count-the-number-of-good-subarrays/submissions/878623208/
/// </summary>
internal class P2537
{
  public class Solution
  {
    public long CountGood(int[] nums, int k)
    {
      // sliding window

      var map = new Dictionary<int, int>();
      var runningSum = 0L;

      var leftBoundary = 0;
      var ans = 0L;

      for (int i = 0; i < nums.Length; i++)
      {
        var el = nums[i];

        map.TryAdd(el, 0);
        runningSum = AddElement(el, map, runningSum);

        // shift left
        if (runningSum < k)
        {
          while (runningSum < k && leftBoundary > 0)
          {
            leftBoundary--;
            runningSum = AddElement(nums[leftBoundary], map, runningSum);
          }

          ans += (runningSum >= k) ? (leftBoundary + 1) : 0;
        }

        // or shift right
        else if (runningSum >= k)
        {
          while (runningSum >= k)
          {
            leftBoundary++;
            runningSum = RemoveElement(nums[leftBoundary - 1], map, runningSum);
          }

          ans += leftBoundary;
        }
      }

      return ans;
    }

    private long AddElement(int el, Dictionary<int, int> map, long runningSum)
    {
      map[el]++;

      var prev = (map[el] - 1) * (map[el] - 2) / 2L;
      var curr = map[el] * (map[el] - 1) / 2L;

      runningSum += curr - prev;
      return runningSum;
    }

    private long RemoveElement(int el, Dictionary<int, int> map, long runningSum)
    {
      map[el]--;

      var prev = (map[el] + 1) * (map[el]) / 2L;
      var curr = map[el] * (map[el] - 1) / 2L;

      runningSum -= (prev - curr);
      return runningSum;
    }
  }

}
