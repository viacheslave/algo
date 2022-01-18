using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3696/
  /// 
  /// </summary>
  internal class Apr04
  {
    public class MyCircularQueue
    {
      private readonly int _k;
      private readonly LinkedList<int> _list;

      /** Initialize your data structure here. Set the size of the queue to be k. */
      public MyCircularQueue(int k)
      {
        _k = k;
        _list = new LinkedList<int>();
      }

      /** Insert an element into the circular queue. Return true if the operation is successful. */
      public bool EnQueue(int value)
      {
        if (IsFull()) return false;
        _list.AddLast(value);
        return true;
      }

      /** Delete an element from the circular queue. Return true if the operation is successful. */
      public bool DeQueue()
      {
        if (IsEmpty()) return false;
        _list.RemoveFirst();
        return true;
      }

      /** Get the front item from the queue. */
      public int Front()
      {
        if (IsEmpty()) return -1;
        return _list.First.Value;
      }

      /** Get the last item from the queue. */
      public int Rear()
      {
        if (IsEmpty()) return -1;
        return _list.Last.Value;
      }

      /** Checks whether the circular queue is empty or not. */
      public bool IsEmpty()
      {
        return _list.Count == 0;
      }

      /** Checks whether the circular queue is full or not. */
      public bool IsFull()
      {
        return _list.Count == _k;
      }
    }

    /**
     * Your MyCircularQueue object will be instantiated and called as such:
     * MyCircularQueue obj = new MyCircularQueue(k);
     * bool param_1 = obj.EnQueue(value);
     * bool param_2 = obj.DeQueue();
     * int param_3 = obj.Front();
     * int param_4 = obj.Rear();
     * bool param_5 = obj.IsEmpty();
     * bool param_6 = obj.IsFull();
     */
  }
}
