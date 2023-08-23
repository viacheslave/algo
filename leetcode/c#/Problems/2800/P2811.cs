namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/check-if-it-is-possible-to-split-array/
///    Submission: https://leetcode.com/problems/check-if-it-is-possible-to-split-array/submissions/1019246260/
/// </summary>
internal class P2811
{
  public class Solution
  {
    public bool CanSplitArray(IList<int> nums, int m)
    {
      // prefix sum
      // bottom-up DP

      var prefixSum = new int[nums.Count + 1];
      for (int i = 0; i < nums.Count; i++)
      {
        prefixSum[i + 1] = prefixSum[i] + nums[i];
      }

      var canSplit = new Dictionary<(int from, int to), bool>();

      for (int i = 0; i < nums.Count; i++)
        canSplit[(i, i)] = true;

      for (int length = 0; length < nums.Count; length++)
      {
        for (int start = 0; start < nums.Count - length; start++)
        {
          var tuple = (from: start, to: start + length);
          if (canSplit.ContainsKey(tuple))
            continue;

          if (length != nums.Count - 1)
          {
            if (prefixSum[tuple.to + 1] - prefixSum[tuple.from] < m)
            {
              canSplit[tuple] = false;
              continue;
            }
          }

          var can = false;

          for (int bet = tuple.from; bet < tuple.to; bet++)
          {
            can |= canSplit[(tuple.from, bet)] && canSplit[(bet + 1, tuple.to)];
          }

          canSplit[tuple] = can;
        }
      }

      return canSplit[(0, nums.Count - 1)];
    }
  }
}
