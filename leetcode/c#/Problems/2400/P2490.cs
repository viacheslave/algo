namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/circular-sentence/
///    Submission: https://leetcode.com/problems/circular-sentence/submissions/854386046/
/// </summary>
internal class P2490
{
  public class Solution
  {
    public bool IsCircularSentence(string sentence)
    {
      var words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

      for (int i = 0; i < words.Length; i++)
      {
        var p1 = words[i][^1];
        var p2 = (i == words.Length - 1) ? words[0][0] : words[i + 1][0];

        if (p1 != p2)
        {
          return false;
        }
      }

      return true;
    }
  }
}
