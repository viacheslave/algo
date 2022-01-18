using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3410/
  ///    https://leetcode.com/submissions/detail/374883552/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3410/
  /// </summary>
  internal class Aug02
  {
    public class MyHashSet
    {
      private readonly LinkedList<int>[] _entries = new LinkedList<int>[31];

      /** Initialize your data structure here. */
      public MyHashSet()
      {
        for (int i = 0; i < 31; i++)
        {
          _entries[i] = new LinkedList<int>();
        }
      }

      public void Add(int key)
      {
        var index = GetIndex(key);
        var bucket = _entries[index];

        if (!bucket.Contains(key))
          bucket.AddLast(key);
      }

      public void Remove(int key)
      {
        var index = GetIndex(key);
        var bucket = _entries[index];

        var node = bucket.Find(key);
        if (node != null)
          bucket.Remove(key);
      }

      /** Returns true if this set contains the specified element */
      public bool Contains(int key)
      {
        var index = GetIndex(key);
        var bucket = _entries[index];

        return bucket.Contains(key);
      }

      private static int GetIndex(int key)
      {
        return key.GetHashCode() % 31;
      }
    }
  }
}
