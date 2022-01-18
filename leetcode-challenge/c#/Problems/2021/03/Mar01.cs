using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3657/
  /// 
  /// </summary>
  internal class Mar01
  {
    public class Solution
    {
      public int DistributeCandies(int[] candies)
      {
        var map = candies.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count())
            .OrderBy(_ => _.Value)
            .ToDictionary(_ => _.Key, _ => _.Value);

        var items = new HashSet<int>();

        var index = 0;
        while (true)
        {
          var keysToRemove = new List<int>();

          foreach (var item in map)
          {
            index++;
            if (index > candies.Length / 2)
              return items.Count;

            var key = item.Key;
            items.Add(key);

            if (item.Value == 1)
              keysToRemove.Add(key);
          }

          foreach (var r in keysToRemove)
            map.Remove(r);
        }
      }
    }
  }
}
