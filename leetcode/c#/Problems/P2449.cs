namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-make-arrays-similar/
///    Submission: https://leetcode.com/problems/minimum-number-of-operations-to-make-arrays-similar/submissions/829453092/
/// </summary>
internal class P2449
{
  public class Solution
  {
    public long MakeSimilar(int[] nums, int[] target)
    {
      // leave only diff elements
      Array.Sort(nums);
      Array.Sort(target);

      var zipped = nums.Zip(target).Where((a) => a.First != a.Second).ToList();

      nums = zipped.Select(z => z.First).ToArray();
      target = zipped.Select(z => z.Second).ToArray();

      var odd = Solve(
        nums.Where(n => n % 2 == 1).ToArray(),
        target.Where(n => n % 2 == 1).ToArray());

      var even = Solve(
        nums.Where(n => n % 2 == 0).ToArray(),
        target.Where(n => n % 2 == 0).ToArray());

      return (odd + even) / 2;
    }

    private long Solve(int[] nums, int[] target)
    {
      return nums.Zip(target)
        .Select(x => Math.Abs(1L * x.First - 1L * x.Second) / 2)
        .Sum();
    }
  }
}
