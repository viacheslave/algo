namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-duplicates-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/231252408/
/// </summary>
internal class P0442
{
  public class Solution
  {
    public IList<int> FindDuplicates(int[] nums)
    {
      var res = new List<int>();
      var hs = new Dictionary<int, int>();
      for (var i = 0; i < nums.Length; i++)
      {
        if (!hs.ContainsKey(nums[i]))
          hs[nums[i]] = 0;
        hs[nums[i]]++;
      }
      return hs.Where(_ => _.Value > 1).Select(_ => _.Key).ToList();
    }
  }
}
