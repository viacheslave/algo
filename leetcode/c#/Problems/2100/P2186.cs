namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram-ii/
///    Submission: https://leetcode.com/submissions/detail/656676320/
/// </summary>
internal class P2186
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
