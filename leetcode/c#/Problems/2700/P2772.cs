namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/apply-operations-to-make-all-array-elements-equal-to-zero/
///    Submission: https://leetcode.com/problems/apply-operations-to-make-all-array-elements-equal-to-zero/submissions/1027985034/
/// </summary>
internal class P2772
{
  public class Solution
  {
    public bool CheckArray(int[] nums, int k)
    {
      var arr = new int[nums.Length];

      for (int i = 0; i < nums.Length - k + 1; i++)
      {
        var diff = nums[i] - arr[i];

        for (int j = i; j < i + k; j++)
        {
          //if (j >= nums.Length)
          //  break;

          arr[j] += diff;
          if (arr[j] > nums[j])
            return false;
        }
      }

      // check tail
      for (var i = 0; i < nums.Length; i++)
      {
        if (arr[i] != nums[i])
          return false;
      }

      return true;
    }
  }
}
