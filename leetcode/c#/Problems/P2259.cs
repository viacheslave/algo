namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/remove-digit-from-number-to-maximize-result/
///    Submission: https://leetcode.com/submissions/detail/692114144/
/// </summary>
internal class P2259
{
  public class Solution
  {
    public string RemoveDigit(string number, char digit)
    {
      var strs = new List<string>();

      for (int i = 0; i < number.Length; i++)
      {
        if (digit == number[i])
        {
          strs.Add(number.Remove(i, 1));
        }
      }

      strs.Sort();

      return strs[^1];
    }
  }
}
