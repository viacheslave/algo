namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/best-poker-hand/
///    Submission: https://leetcode.com/submissions/detail/755499496/
/// </summary>
internal class P2347
{
  public class Solution
  {
    public string BestHand(int[] ranks, char[] suits)
    {
      if (suits.Distinct().Count() == 1)
        return "Flush";

      var maxLength = ranks.GroupBy(d => d).MaxBy(x => x.Count()).Count();

      return maxLength switch
      {
        3 or 4 => "Three of a Kind",
        2 => "Pair",
        _ => "High Card"
      };
    }
  }
}
