namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/make-string-a-subsequence-using-cyclic-increments/
///    Submission: https://leetcode.com/problems/make-string-a-subsequence-using-cyclic-increments/submissions/1030733722/
/// </summary>
internal class P2825
{
  public class Solution
  {
    public bool CanMakeSubsequence(string str1, string str2)
    {
      if (str2.Length > str1.Length)
        return false;

      var ind = 0;

      for (int i = 0; i < str1.Length; i++)
      {
        var next = (char)(((str1[i] + 1 - 97) % 26) + 97);

        if (str1[i] == str2[ind] || next == str2[ind])
        {
          ind++;

          if (ind == str2.Length)
            return true;
        }
      }

      return false;
    }
  }
}
