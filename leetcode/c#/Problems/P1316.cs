namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/distinct-echo-substrings/
///    Submission: https://leetcode.com/submissions/detail/426199202/
/// </summary>
internal class P1316
{
  public class Solution
  {
    public int DistinctEchoSubstrings(string text)
    {
      const int A = 911382323;
      const int B = 972663749;

      var h = new int[text.Length];
      var p = new int[text.Length];

      h[0] = text[0] % B;
      p[0] = 1;

      for (var i = 1; i < text.Length; i++)
      {
        h[i] = (Mod(h[i - 1], A, B) + text[i]) % B;
        p[i] = (Mod(p[i - 1], A, B)) % B;
      }

      var set = new HashSet<int>();

      for (var i = 0; i < text.Length; i++)
      {
        for (var j = i + 1; j < text.Length; j += 2)
        {
          var hash1 = Hash(h, p, i, (i + j) / 2, B);
          var hash2 = Hash(h, p, (i + j) / 2 + 1, j, B);

          if (hash1 == hash2)
            set.Add(Hash(h, p, i, j, B));
        }
      }

      return set.Count;
    }

    private int Hash(int[] h, int[] p, int a, int b, int B)
    {
      if (a == 0)
        return h[b];

      return ((h[b] + B) - Mod(h[a - 1], p[b - a + 1], B)) % B;
    }

    private int Mod(int a, int b, int mod)
    {
      var res = 0;
      a %= mod;

      while (b > 0)
      {
        if ((b & 1) > 0)
          res = (res + a) % mod;

        a = (2 * a) % mod;
        b >>= 1;
      }

      return res;
    }
  }
}
