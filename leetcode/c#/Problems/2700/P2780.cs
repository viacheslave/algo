namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/minimum-index-of-a-valid-split/
///    Submission: https://leetcode.com/problems/minimum-index-of-a-valid-split/submissions/1001664252/
/// </summary>
internal class P2780
{
  public class Solution
  {
    public int MinimumIndex(IList<int> nums)
    {
      var dominant = nums.GroupBy(n => n)
        .OrderByDescending(x => x.Count())
        .Select(x => x.Key)
        .First();

      var allDomCount = nums.Count(n => n == dominant);

      var leftDomCount = 0;

      for (int i = 0; i < nums.Count - 1; i++)
      {
        var ll = i + 1;
        var rl = nums.Count - ll;

        if (nums[i] == dominant)
          leftDomCount++;

        if (leftDomCount * 2 > ll && (allDomCount - leftDomCount) * 2 > rl)
          return i;
      }

      return -1;
    }
  }
}
