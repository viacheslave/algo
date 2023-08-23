namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/continuous-subarrays/
///    Submission: https://leetcode.com/problems/continuous-subarrays/submissions/1025214528/
/// </summary>
internal class P2762
{
  public class Solution
  {
    public long ContinuousSubarrays(int[] nums)
    {
      var dict = new SortedList<int, int>();

      var left = 0;
      var right = 0;

      var ans = 0L;

      // sliding window
      while (right < nums.Length)
      {
        Add(nums, dict, right);

        while (!Fits(dict))
        {
          Remove(nums, dict, left);
          left++;
        }

        ans += GetInc(left, right);
        right++;
      }

      return ans;

      static long GetInc(int left, int right)
      {
        var len = right - left + 1;
        //return len * (len + 1) / 2;
        return len;
      }

      static void Add(int[] nums, SortedList<int, int> dict, int right)
      {
        if (!dict.ContainsKey(nums[right]))
          dict[nums[right]] = 0;

        dict[nums[right]]++;
      }

      static void Remove(int[] nums, SortedList<int, int> dict, int left)
      {
        dict[nums[left]]--;
        if (dict[nums[left]] == 0)
          dict.Remove(nums[left]);
      }

      static bool Fits(SortedList<int, int> dict)
      {
        return dict.Keys[^1] - dict.Keys[0] <= 2;
      }
    }
  }
}
