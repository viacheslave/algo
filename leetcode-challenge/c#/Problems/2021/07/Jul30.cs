using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/612/week-5-july-29th-july-31st/3832/
  /// 
  /// </summary>
  internal class Jul30
  {
    public class MapSum
    {
      SortedDictionary<string, int> sd = new SortedDictionary<string, int>();

      /** Initialize your data structure here. */
      public MapSum()
      {
      }

      public void Insert(string key, int val)
      {
        sd[key] = val;
      }

      public int Sum(string prefix)
      {
        return sd.Where(_ => _.Key.StartsWith(prefix)).Sum(_ => _.Value);
      }
    }

    /**
     * Your MapSum object will be instantiated and called as such:
     * MapSum obj = new MapSum();
     * obj.Insert(key,val);
     * int param_2 = obj.Sum(prefix);
     */
  }
}
