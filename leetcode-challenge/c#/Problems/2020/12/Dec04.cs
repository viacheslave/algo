namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3554/
  ///    https://leetcode.com/submissions/detail/427066534/?from=explore&item_id=3554
  /// </summary>
  internal class Dec04
  {
    class Solution
    {
      public int KthFactor(int n, int k)
      {
        var th = 0;

        for (int i = 1; i <= n; i++)
        {
          if (n % i == 0)
          {
            th++;
            if (th == k)
              return i;
          }
        }

        return -1;
      }
    }
  }
}
