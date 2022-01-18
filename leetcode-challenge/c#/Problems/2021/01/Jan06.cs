using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3594/
  ///    https://leetcode.com/submissions/detail/439286442/?from=explore&item_id=3594
  /// </summary>
  internal class Jan06
  {
    public class Solution
    {
      public int FindKthPositive(int[] arr, int k)
      {
        var missing = new List<int>();

        var current = 1;

        for (int i = 0; i < arr.Length; i++)
        {
          while (arr[i] != current)
          {
            missing.Add(current);
            if (missing.Count == k)
              return current;

            current++;
          }

          current++;
        }

        while (true)
        {
          missing.Add(current);
          if (missing.Count == k)
            return current;

          current++;
        }

        return -1;
      }
    }
  }
}

