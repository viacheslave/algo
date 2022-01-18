using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/610/week-3-july-15th-july-21st/3820/
  /// 
  /// </summary>
  internal class Jul20
  {
    public class Solution
    {

      List<int> original;
      Random rnd = new Random((int)DateTime.Now.Ticks);

      public Solution(int[] nums)
      {
        original = new List<int>(nums);
      }

      /** Resets the array to its original configuration and return it. */
      public int[] Reset()
      {
        return original.ToArray();
      }

      /** Returns a random shuffling of the array. */
      public int[] Shuffle()
      {
        var l = new List<int>(original);

        var length = l.Count;
        var result = new List<int>(original.Count);

        while (length > 0)
        {
          var i = rnd.Next(0, length);
          result.Add(l[i]);

          l.RemoveAt(i);
          length--;
        }

        return result.ToArray();
      }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int[] param_1 = obj.Reset();
     * int[] param_2 = obj.Shuffle();
     */
  }
}
