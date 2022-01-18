using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/first-unique-number/
  ///    Submission: https://leetcode.com/submissions/detail/458339261/
  ///    All
  /// </summary>
  internal class P1429
  {
    public class FirstUnique
    {
      private LinkedList<int> _queue = new LinkedList<int>();
      private Dictionary<int, LinkedListNode<int>> _queueMap = new Dictionary<int, LinkedListNode<int>>();
      private Dictionary<int, int> _set = new Dictionary<int, int>();

      public FirstUnique(int[] nums)
      {
        _set = nums.GroupBy(d => d).ToDictionary(c => c.Key, c => c.Count());

        foreach (var num in nums)
        {
          if (_set[num] == 1)
          {
            var node = _queue.AddLast(num);
            _queueMap[num] = node;
          }
        }
      }

      public int ShowFirstUnique()
      {
        if (_queue.Count == 0)
          return -1;

        return _queue.First.Value;
      }

      public void Add(int value)
      {
        if (!_set.ContainsKey(value))
        {
          var node = _queue.AddLast(value);
          _queueMap[value] = node;
          _set[value] = 1;
          return;
        }

        if (_set[value] > 1)
          return;

        _set[value]++;
        var item = _queueMap[value];
        _queue.Remove(item);
        _queueMap.Remove(value);
      }
    }
  }
}
