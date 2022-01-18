using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3589/
  ///    https://leetcode.com/submissions/detail/437072686/?from=explore&item_id=3589
  /// </summary>
  internal class Jan01
  {
    public class Solution
    {
      public bool CanFormArray(int[] arr, int[][] pieces)
      {
        var list = arr.ToList();
        var sets = pieces.Select(s => s.ToList()).ToList();

        while (list.Count > 0)
        {
          var set = sets.FirstOrDefault(s =>
              list.Count >= s.Count &&
              list.Take(s.Count).Select((x, i) => (x, i)).All(x => x.x == s[x.i]));

          if (set == null)
            return false;

          list = list.Skip(set.Count).ToList();
        }

        return true;
      }
    }
  }
}
