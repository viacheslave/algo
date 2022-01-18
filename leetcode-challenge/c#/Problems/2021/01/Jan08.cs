using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3597/
  ///    https://leetcode.com/submissions/detail/440196669/?from=explore&item_id=3597
  /// </summary>
  internal class Jan08
  {
    public class Solution
    {
      public bool ArrayStringsAreEqual(string[] word1, string[] word2) =>
        word1.Aggregate(new StringBuilder(), (sb, w) => sb.Append(w)).ToString() ==
        word2.Aggregate(new StringBuilder(), (sb, w) => sb.Append(w)).ToString();
    }
  }
}

