using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3480/
  ///    https://leetcode.com/submissions/detail/403015981/?from=/explore/featured/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3480/
  /// </summary>
  internal class Oct01
  {
    public class RecentCounter
    {
      LinkedList<int> exp = new LinkedList<int>();

      public RecentCounter()
      {
      }

      public int Ping(int t)
      {
        return Add(t);
      }

      int Add(int value)
      {
        var expirationValue = value + 3000;

        if (exp.First == null || expirationValue <= exp.First.Value)
        {
          exp.AddFirst(expirationValue);
          return 1;
        }

        var current = exp.First;
        while (current != null)
        {
          if (expirationValue == current.Value)
          {
            exp.AddBefore(current, expirationValue);
            return exp.Count;
          }

          if (expirationValue < current.Value)
          {
            exp.AddAfter(current.Previous, expirationValue);
            return exp.Count;
          }

          var tmpCurrent = current;
          current = current.Next;

          if (tmpCurrent.Value < value)
            exp.RemoveFirst();
        }

        if (exp.Last == null)
        {
          exp.AddFirst(expirationValue);
        }
        else
        {
          exp.AddAfter(exp.Last, expirationValue);
        }

        return exp.Count;
      }
    }

    /**
     * Your RecentCounter object will be instantiated and called as such:
     * RecentCounter obj = new RecentCounter();
     * int param_1 = obj.Ping(t);
     */
  }
}
