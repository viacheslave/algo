using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3427/
  ///    https://leetcode.com/submissions/detail/382126244/?from=/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3427/
  /// </summary>
  internal class Aug17
  {
    public class Solution
    {
      public int[] DistributeCandies(int candies, int num_people)
      {
        var sum = num_people * (num_people + 1) / 2;
        var total = 0;
        var row = 0;

        while (total + (sum + (row) * num_people * num_people) < candies)
        {
          total += (sum + (row) * num_people * num_people);
          row++;
        }

        var leftCandies = candies - total;
        var ans = new int[num_people];
        var start = 1 + row * num_people;

        for (int i = 0; i < num_people; i++)
        {
          var load = leftCandies - (start + i) > 0 ? (start + i) : leftCandies;
          var prev = GetPrev(i + 1, row, num_people);

          ans[i] = load + prev;
          leftCandies -= load;
        }

        return ans;
      }

      private int GetPrev(int index, int rows, int num_people)
      {
        var sum = 0;
        for (int i = 0; i < rows; i++)
        {
          sum += (index + i * num_people);
        }

        return sum;
      }
    }
  }
}
