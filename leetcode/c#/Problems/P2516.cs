namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/take-k-of-each-character-from-left-and-right/
///    Submission: https://leetcode.com/problems/take-k-of-each-character-from-left-and-right/submissions/865278353/
/// </summary>
internal class P2516
{
  public class Solution
  {
    public int TakeCharacters(string s, int k)
    {
      // check if possible
      var acc = s.Aggregate((a: 0, b: 0, c: 0), (acc, ch) => Inc(acc, ch, 1));

      if (!Fits(acc, k))
      {
        return -1;
      }

      // two pointers
      var left = -1;
      var right = s.Length;

      acc = (a: 0, b: 0, c: 0);

      var ans = int.MaxValue;

      while (left < s.Length)
      {
        // move right to start
        while (!Fits(acc, k))
        {
          right--;
          acc = Inc(acc, s[right], 1);
        }

        // move right to end
        while (Fits(acc, k))
        {
          if (right == s.Length)
            break;

          var candidate = Inc(acc, s[right], -1);
          if (!Fits(candidate, k))
            break;

          acc = candidate;
          right++;
        }

        ans = Math.Min(ans, left + 1 + s.Length - right);

        left++;
        if (left == s.Length)
          break;

        acc = Inc(acc, s[left], 1);

        if (left == right)
        {
          if (left == s.Length - 1)
            break;

          acc = Inc(acc, s[right], -1);
          right++;
        }
      }

      return ans;
    }

    private static (int a, int b, int c) Inc((int a, int b, int c) acc, char ch, int diff)
    {
      return ch switch
      {
        'a' => (acc.a + diff, acc.b, acc.c),
        'b' => (acc.a, acc.b + diff, acc.c),
        _ => (acc.a, acc.b, acc.c + diff),
      };
    }

    private static bool Fits((int a, int b, int c) acc, int k)
    {
      return acc.a >= k && acc.b >= k && acc.c >= k;
    }
  }
}
