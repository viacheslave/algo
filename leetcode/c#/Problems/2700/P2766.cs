namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/relocate-marbles/
///    Submission: https://leetcode.com/problems/relocate-marbles/submissions/1025952025/
/// </summary>
internal class P2766
{
  public class Solution
  {
    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
    {
      var map = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

      for (int i = 0; i < moveFrom.Length; i++)
      {
        if (moveFrom[i] == moveTo[i])
          continue;

        if (map.ContainsKey(moveFrom[i]))
        {
          var n = map[moveFrom[i]];

          map.TryAdd(moveTo[i], 0);
          map[moveTo[i]] += n;

          map.Remove(moveFrom[i]);
        }
      }

      return map.Keys.OrderBy(x => x).ToList();
    }
  }
}
