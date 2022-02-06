namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sort-even-and-odd-indices-independently/
///    Submission: https://leetcode.com/submissions/detail/635648160/
/// </summary>
internal class P2164
{
  public class Solution
  {
    public int[] SortEvenOdd(int[] nums)
    {
      var even = nums.Select((a, i) => (a, i))
        .Where(x => x.i % 2 == 0)
        .Select(x => x.a)
        .OrderBy(x => x)
        .ToArray();

      var odd = nums.Select((a, i) => (a, i))
        .Where(x => x.i % 2 == 1)
        .Select(x => x.a)
        .OrderByDescending(x => x)
        .ToArray();

      var e = 0;
      var o = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        if (i % 2 == 0)
        {
          nums[i] = even[e];
          e++;
        }
        else
        {
          nums[i] = odd[o];
          o++;
        }
      }

      return nums;
    }
  }

}
