using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3431/
  ///	  https://leetcode.com/submissions/detail/384198404/?from=/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3431/
  /// </summary>
  internal class Aug21
  {
    public class Solution {
      public int[] SortArrayByParity(int[] A) {
        return A.Where(_ => _ % 2 == 0).Concat(
          A.Where(_ => _ % 2 == 1))
          .ToArray();
      }
    }
  }
}
