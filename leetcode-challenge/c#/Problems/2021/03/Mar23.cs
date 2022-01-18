using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3682/
  ///   
  /// </summary>
  internal class Mar23
  {
    public class Solution
    {
      public int ThreeSumMulti(int[] A, int target)
      {
        var map = A.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
        var arr = A.Distinct().OrderBy(x => x).ToList();

        var ans = 0L;

        for (var i = 0; i < arr.Count; i++)
        {
          var j = i;
          var k = arr.Count - 1;

          var sum = target - arr[i];
          var a0 = arr[i];

          while (j <= k)
          {
            var a1 = arr[j];
            var a2 = arr[k];

            if (a1 + a2 < sum)
            {
              j++;
              continue;
            }

            if (a1 + a2 > sum)
            {
              k--;
              continue;
            }

            if (i < j && j < k)
            {
              ans += 1L * map[a0] * map[a1] * map[a2];
            }
            else if (i == j && j < k)
            {
              ans += 1L * map[a0] * (map[a0] - 1) / 2 * map[a2];
            }
            else if (i < j && j == k)
            {
              ans += 1L * map[a0] * map[a2] * (map[a2] - 1) / 2;
            }
            else
            {
              ans += 1L * map[a0] * (map[a0] - 1) * (map[a0] - 2) / 6;
            }

            j++;
            k--;
          }
        }

        return (int)(ans % 1_000_000_007);
      }
    }
  }
}
