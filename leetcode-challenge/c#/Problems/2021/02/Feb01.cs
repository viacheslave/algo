namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3625/
  ///    https://leetcode.com/submissions/detail/450507825/?from=explore&item_id=3625
  /// </summary>
  internal class Feb01
  {
    public class Solution
    {
      public int HammingWeight(uint n)
      {
        var i = 32;

        int res = 0;
        while (i-- > 0)
        {
          if ((n % 2) == 1)
            res++;

          n = n >> 1;
        }


        return res;
      }
    }
  }
}
