using System;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-days-in-a-month/
  ///    Submission: https://leetcode.com/submissions/detail/451173575/
  ///    Amazon
  /// </summary>
  internal class P1118
  {
    public class Solution
    {
      public int NumberOfDays(int Y, int M)
      {
        if (M != 2)
        {
          if (M == 1 || M == 3 || M == 5 ||
              M == 7 || M == 8 || M == 10 || M == 12)
            return 31;
          return 30;
        }

        if (Y % 100 == 0 && Y % 400 != 0)
          return 28;

        if (Y % 4 == 0)
          return 29;

        return 28;
      }
    }
  }
}
