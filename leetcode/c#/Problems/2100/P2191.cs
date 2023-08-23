namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sort-the-jumbled-numbers/
///    Submission: https://leetcode.com/submissions/detail/656667778/
/// </summary>
internal class P2191
{
  public class Solution
  {
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
      var sbs = nums
        .Select(x => new StringBuilder(x.ToString()))
        .Select((x, a) =>
        {
          for (var i = 0; i < x.Length; i++)
            x[i] = char.Parse(mapping[int.Parse(x[i].ToString())].ToString());

          return (int.Parse(x.ToString()), a);
        });

      return sbs
        .OrderBy(x => x.Item1)
        .Select(x => x.a)
        .Select(x => nums[x])
        .ToArray();
    }
  }
}
