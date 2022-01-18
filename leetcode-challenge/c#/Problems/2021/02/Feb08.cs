using System;
using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3633/
  ///    
  /// </summary>
  internal class Feb08
  {
    // C# IEnumerator interface reference:
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

    class PeekingIterator
    {
      private int? _next = null;

      private readonly IEnumerator<int> _iterator;

      // iterators refers to the first element of the array.
      public PeekingIterator(IEnumerator<int> iterator)
      {
        _iterator = iterator;

        _next = _iterator.Current;
      }

      // Returns the next element in the iteration without advancing the iterator.
      public int Peek()
      {
        return _next.GetValueOrDefault();
      }

      // Returns the next element in the iteration and advances the iterator.
      public int Next()
      {
        var value = _next.GetValueOrDefault();

        _next = _iterator.MoveNext()
          ? _iterator.Current
          : (int?)null;

        return value;
      }

      // Returns false if the iterator is refering to the end of the array of true otherwise.
      public bool HasNext()
      {
        return _next.HasValue;
      }
    }
  }
}
