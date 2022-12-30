namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/
///    Submission: https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/submissions/868084809/
/// </summary>
internal class P2411
{
  public class Solution
  {
    public int[] SmallestSubarrays(int[] nums)
    {
      // greedy
      // from right to left update mask arr
      // mask arr tells where the '1' leftmost digit is located
      // '1' digit maximize OR
      // by checking the max of mask we tell the distance of the maximum OR value

      var mask = new int[31];
      Array.Fill(mask, -1);

      var ans = new int[nums.Length];

      for (int i = nums.Length - 1; i >= 0; i--)
      {
        var num = nums[i];

        // update mask

        var index = 0;
        while (num > 0)
        {
          if (num % 2 == 1)
          {
            mask[index] = i;
          }

          num >>= 1;
          index++;
        }

        // calculate distance

        var maxIndex = mask.Max();

        if (maxIndex == -1)
          maxIndex = i;

        ans[i] = maxIndex - i + 1;
      }

      return ans;
    }
  }
  Console

}
