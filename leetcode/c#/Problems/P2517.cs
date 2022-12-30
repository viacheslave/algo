namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-tastiness-of-candy-basket/
///    Submission: https://leetcode.com/problems/maximum-tastiness-of-candy-basket/submissions/865312696/
/// </summary>
internal class P2517
{
  public class Solution
  {
    public int MaximumTastiness(int[] price, int k)
    {
      Array.Sort(price);

      // binary search
      // rightmost

      var left = 0;
      var right = price[^1] - price[0] + 1;

      while (left < right)
      {
        var mid = (left + right) >> 1;

        if (Fits(price, k, mid))
        {
          left = mid + 1;
        }
        else
        {
          right = mid;
        }
      }

      return right - 1;
    }

    private bool Fits(int[] price, int k, int mid)
    {
      var arr = new List<int>() { price[0] };

      for (int i = 1; i < price.Length; i++)
      {
        if (price[i] - arr[^1] >= mid)
        {
          arr.Add(price[i]);
          if (arr.Count == k)
          {
            return true;
          }
        }
      }

      return false;
    }
  }

}
