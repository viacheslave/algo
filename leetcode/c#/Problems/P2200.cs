namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-k-distant-indices-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/689863597/
/// </summary>
internal class P2200
{
  public class Solution
  {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
      var ss = new SortedSet<int>();

      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] == key)
        {
          for (int j = i - k; j <= i + k; j++)
          {
            if (j >= 0 && j < nums.Length)
              ss.Add(j);
          }
        }
      }

      return ss.ToList();
    }
  }
}
