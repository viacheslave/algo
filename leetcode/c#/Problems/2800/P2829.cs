namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/determine-the-minimum-sum-of-a-k-avoiding-array/
///    Submission: https://leetcode.com/problems/determine-the-minimum-sum-of-a-k-avoiding-array/submissions/1030225707/
/// </summary>
internal class P2829
{
  public class Solution
  {
    public int MinimumSum(int n, int k)
    {
      var set = new HashSet<int>();

      var current = 1;
      while (set.Count < n)
      {
        if (!set.Contains(current) && !set.Contains(k - current))
        {
          set.Add(current);
        }
        current++;
      }

      return set.Sum();
    }
  }
}
