using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/609/week-2-july-8th-july-14th/3810/
  /// 
  /// </summary>
  internal class Jul11
  {
    public class MedianFinder
    {
      SortedList<Value, Value> _values = new SortedList<Value, Value>();

      /** initialize your data structure here. */
      public MedianFinder()
      {
      }

      public void AddNum(int num)
      {
        Value value = new Value { value = num, stamp = DateTime.Now.Ticks };
        _values.Add(value, value);
      }

      public double FindMedian()
      {
        if (_values.Count % 2 == 1)
          return _values.Keys[(_values.Count - 1) / 2].value;

        return 1.0 * (_values.Keys[_values.Count / 2].value + _values.Keys[_values.Count / 2 - 1].value) / 2;
      }

      public class Value : IComparable<Value>
      {
        public int value;
        public long stamp;

        public int CompareTo(Value other)
        {
          if (value == other.value)
            return stamp.CompareTo(other.stamp);

          return value.CompareTo(other.value);
        }

        public override bool Equals(object obj)
        {
          var other = (Value)obj;
          return (other.value == this.value) && (other.stamp == this.stamp);
        }

        public override int GetHashCode()
        {
          unchecked
          {
            return value.GetHashCode() ^ stamp.GetHashCode();
          }
        }
      }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
  }
}
