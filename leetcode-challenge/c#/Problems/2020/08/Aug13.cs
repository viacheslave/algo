using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3422/
  ///    https://leetcode.com/submissions/detail/380247462/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3422/
  /// </summary>
  internal class Aug13
  {
    public class CombinationIterator
    {
      private readonly int combinationLength;
      private readonly IEnumerator<string> enumerator;
      private readonly List<char> chars;
      private string last;
      private string lastPossible;

      public CombinationIterator(string characters, int combinationLength)
      {
        chars = characters.ToList();
        this.combinationLength = combinationLength;

        lastPossible = new string(characters.TakeLast(combinationLength).ToArray());

        enumerator = Get(new List<char>(), 0).GetEnumerator();
      }

      public string Next()
      {
        if (enumerator.MoveNext())
        {
          last = enumerator.Current;
          return last;
        }

        return null;
      }

      private IEnumerable<string> Get(List<char> result, int index)
      {
        if (result.Count == combinationLength)
          yield return new string(result.ToArray());

        for (var i = index; i < chars.Count; i++)
        {
          result.Add(chars[i]);

          foreach (var res in Get(result, i + 1))
            yield return res;

          result.RemoveAt(result.Count - 1);
        }
      }

      public bool HasNext()
      {
        return last == null || last != lastPossible;
      }
    }

    /**
     * Your CombinationIterator object will be instantiated and called as such:
     * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
     * string param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
  }
}
