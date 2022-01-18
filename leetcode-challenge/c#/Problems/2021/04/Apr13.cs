using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3706/
  /// 
  /// </summary>
  internal class Apr13
  {
    /**
    * // This is the interface that allows for creating nested lists.
    * // You should not implement it, or speculate about its implementation*/
    public interface NestedInteger {
    
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();
    
        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();
    
        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
    
    public class NestedIterator
    {
      List<int> _items = new List<int>();
      int _currentIndex = -1;

      public NestedIterator(IList<NestedInteger> nestedList)
      {
        foreach (NestedInteger item in nestedList)
          _items.AddRange(Parse(item));
      }

      private List<int> Parse(NestedInteger nested)
      {
        var values = new List<int>();

        if (nested.IsInteger())
        {
          values.Add(nested.GetInteger());
        }

        if (nested.GetList() != null)
        {
          var listItems = nested.GetList().SelectMany(Parse);
          values.AddRange(listItems);
        }

        return values;
      }

      public bool HasNext()
      {
        return _currentIndex < _items.Count - 1;
      }

      public int Next()
      {
        _currentIndex++;
        return _items[_currentIndex];
      }
    }
    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */
  }
}
