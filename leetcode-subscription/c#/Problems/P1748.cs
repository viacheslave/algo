using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-unique-elements/
  ///    Submission: https://leetcode.com/submissions/detail/453161133/
  ///    
  ///    
  /// </summary>
  internal class P1748
  {
    public class Solution
    {
      public int SumOfUnique(int[] nums)
      {
        return nums.GroupBy(d => d).Where(d => d.Count() == 1)
          .Sum(c => c.Key);
      }
    }
  }
}
