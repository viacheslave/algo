namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-penalty-for-a-shop/
///    Submission: https://leetcode.com/problems/minimum-penalty-for-a-shop/submissions/850622118/
/// </summary>
internal class P2483
{
  public class Solution
  {
    public int BestClosingTime(string customers)
    {
      var left = new int[customers.Length + 1];
      var right = new int[customers.Length + 1];

      for (var i = 0; i < customers.Length; i++)
        left[i + 1] = customers[i] == 'N' ? (left[i] + 1) : left[i];

      for (var i = customers.Length - 1; i >= 0; i--)
        right[i] = customers[i] == 'Y' ? (right[i + 1] + 1) : right[i + 1];

      var min = int.MaxValue;
      var ans = customers.Length;

      for (int i = 0; i <= customers.Length; i++)
      {
        if (left[i] + right[i] < min)
        {
          min = left[i] + right[i];
          ans = i;
        }
      }

      return ans;
    }
  }
}
