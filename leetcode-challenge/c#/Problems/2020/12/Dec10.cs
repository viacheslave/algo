namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3561/
  ///    https://leetcode.com/submissions/detail/429161253/?from=explore&item_id=3561
  /// </summary>
  internal class Dec10
  {
    public class Solution
    {
      public bool ValidMountainArray(int[] A)
      {
        if (A.Length < 3)
          return false;

        var up = true;

        for (var i = 1; i < A.Length; i++)
        {
          if (A[i] == A[i - 1])
            return false;

          if (up)
          {
            if (A[i] > A[i - 1])
              continue;

            if (i == 1)
              return false;

            else
              up = false;

            continue;
          }
          else
          {
            if (A[i] < A[i - 1])
              continue;
            else
              return false;
          }

        }

        if (up)
          return false;

        return true;
      }
    }
  }
}
