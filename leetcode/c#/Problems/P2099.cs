namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-subsequence-of-length-k-with-the-largest-sum/
///    Submission: https://leetcode.com/submissions/detail/600242750/
/// </summary>
internal class P2099
{
  public class Solution
  {
    public int[] MaxSubsequence(int[] nums, int k)
    {
      var sorted = nums.OrderBy(x => x).TakeLast(k).ToArray();

      var map = sorted.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

      var ans = new List<int>(k);

      foreach (var num in nums)
      {
        if (map.ContainsKey(num))
        {
          ans.Add(num);

          map[num]--;
          if (map[num] == 0)
            map.Remove(num);
        }
      }


      return ans.ToArray();
    }
  }
}
