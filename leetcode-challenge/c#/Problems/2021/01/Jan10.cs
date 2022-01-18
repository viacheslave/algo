using System;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3599/
  ///    https://leetcode.com/submissions/detail/441115505/?from=explore&item_id=3599
  /// </summary>
  internal class Jan10
  {
    public class Solution
    {
      public int CreateSortedArray(int[] instructions)
      {
        var ans = 0;
        var mod = (int)1e9 + 7;

        // the idea is to store number of element 
        // less then current in a segment array (power of twos)

        var tree = new Segments((int)1e5 + 1);

        for (int i = 0; i < instructions.Length; i++)
        {
          var less = tree.Get(instructions[i] - 1);
          var greater = i - tree.Get(instructions[i]);
          tree.Add(instructions[i]);

          ans += Math.Min(less, greater);
          ans %= mod;
        }

        return ans;
      }

      internal class Segments
      {
        private readonly int[] _count;
        private readonly int _max;

        public Segments(int max)
        {
          _count = new int[max];
          _max = max;
        }

        public void Add(int number)
        {
          // insert segments
          // ex. 9: 9, 10, 12, 16, 32, 64...

          while (number < _max)
          {
            _count[number]++;
            number += number & -number;
          }
        }

        public int Get(int number)
        {
          // try find segments
          // ex. 11: 10, 8

          var res = 0;
          while (number > 0)
          {
            res += _count[number];
            number -= number & -number;
          }
          return res;
        }
      }
    }
  }
}

