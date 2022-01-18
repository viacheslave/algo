using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/max-stack/
  ///    Submission: https://leetcode.com/submissions/detail/452056687/
  ///    All
  /// </summary>
  internal class P0716
  {
    public class MaxStack
    {
      private SortedSet<LinkedListNode<Element>> _set = new SortedSet<LinkedListNode<Element>>(new LLComparer());
      private LinkedList<Element> _ll = new LinkedList<Element>();

      /** initialize your data structure here. */
      public MaxStack()
      {

      }

      public void Push(int x)
      {
        var element = new Element(x, DateTime.UtcNow);
        var node = _ll.AddLast(element);
        _set.Add(node);
      }

      public int Pop()
      {
        var node = _ll.Last;

        _ll.RemoveLast();
        _set.Remove(node);

        return node.Value.V;
      }

      public int Top()
      {
        return _ll.Last.Value.V;
      }

      public int PeekMax()
      {
        return _set.Max.Value.V;
      }

      public int PopMax()
      {
        var node = _set.Max;

        _set.Remove(node);
        _ll.Remove(node);

        return node.Value.V;
      }

      public class LLComparer : IComparer<LinkedListNode<Element>>
      {
        public int Compare(LinkedListNode<Element> x, LinkedListNode<Element> y)
        {
          if (x.Value.V == y.Value.V)
            return x.Value.Stamp.CompareTo(y.Value.Stamp);

          return x.Value.V.CompareTo(y.Value.V);
        }
      }

      public class Element
      {
        public int V { get; }
        public DateTime Stamp { get; }

        public Element(int v, DateTime stamp)
        {
          V = v;
          Stamp = stamp;
        }
      }
    }
  }
}
