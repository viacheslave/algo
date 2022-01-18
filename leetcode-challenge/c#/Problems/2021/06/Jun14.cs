using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/604/week-2-june-8th-june-14th/3778/
  /// 
  /// </summary>
  internal class Jun14
  {
    public class Solution
    {
      public int MaximumUnits(int[][] boxTypes, int truckSize)
      {
        var boxes = boxTypes.Select(x => (count: x[0], units: x[1]))
          .OrderByDescending(x => x.units)
          .ToList();

        var ans = 0;

        for (var i = 0; i < boxes.Count; i++)
        {
          var box = boxes[i];
          var take = truckSize >= box.count ? box.count : truckSize;

          ans += take * box.units;
          truckSize -= take;

          if (truckSize == 0)
            break;
        }

        return ans;
      }
    }
  }
}
