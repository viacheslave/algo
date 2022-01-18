using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/zigzag-iterator/
  ///    Submission: https://leetcode.com/submissions/detail/452390693/
  ///    Yandex
  /// </summary>
  internal class P0281
  {
    public class ZigzagIterator
    {
      private IEnumerator<int> it1;
      private IEnumerator<int> it2;
      private int order = 0;

      private bool it1_has;
      private bool it2_has;

      public ZigzagIterator(IList<int> v1, IList<int> v2)
      {
        it1 = v1.GetEnumerator();
        it2 = v2.GetEnumerator();

        it1_has = it1.MoveNext();
        it2_has = it2.MoveNext();
      }

      public bool HasNext()
      {
        return it1_has || it2_has;
      }

      public int Next()
      {
        if (order == 0)
        {
          if (it1_has)
            return Get1();

          if (it2_has)
            return Get2();
        }
        else
        {
          if (it2_has)
            return Get2();

          if (it1_has)
            return Get1();
        }

        return -1;

        int Get1()
        {
          order = 1 - order;
          var el = it1.Current;

          it1_has = it1.MoveNext();
          return el;
        }

        int Get2()
        {
          order = 1 - order;
          var el = it2.Current;

          it2_has = it2.MoveNext();
          return el;
        }
      }
    }
  }
}
