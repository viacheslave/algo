namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-swaps-to-make-the-string-balanced/
///    Submission: https://leetcode.com/submissions/detail/538065583/
/// </summary>
internal class P1963
{
  public class Solution
  {
    public int MinSwaps(string s)
    {
      var sb = new StringBuilder(s);
      var ans = 0;
      var open = 0;
      var closed = 0;
      var swap = s.Length - 1;

      for (var i = 0; i < s.Length; i++)
      {
        if (sb[i] == '[') open++;
        else closed++;

        if (closed > open)
        {
          while (sb[swap] != '[')
            swap--;

          if (swap < i)
            break;

          sb[i] = '[';
          sb[swap] = ']';

          ans++;
          closed--;
          open++;

        }
      }

      return ans;
    }
  }
}
