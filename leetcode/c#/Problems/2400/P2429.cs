using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimize-xor/
///    Submission: https://leetcode.com/problems/minimize-xor/submissions/816439164/
/// </summary>
internal class P2429
{
  public class Solution
  {
    public int MinimizeXor(int num1, int num2)
    {
      var ones = BitOperations.PopCount((uint)num2);

      var bits = new int[32];
      var index = 0;

      while (num1 > 0)
      {
        if (num1 % 2 == 1)
          bits[31 - index] = 1;

        num1 >>= 1;
        index++;
      }

      // fill ones in bits from left to right
      var ans = new int[32];
      var filled = 0;

      for (int i = 0; i < 32; i++)
      {
        if (bits[i] == 1)
        {
          ans[i] = 1;
          filled++;
        }

        if (filled == ones)
          break;
      }

      // fill zeros in bits right to left
      if (filled < ones)
      {
        for (int i = 31; i >= 0; i--)
        {
          if (bits[i] == 0)
          {
            ans[i] = 1;
            filled++;
          }

          if (filled == ones)
            break;
        }
      }

      var ret = 0;

      for (int i = 31; i >= 0; i--)
      {
        if (ans[i] == 1)
        {
          ret += 1 << (31 - i);
        }
      }

      return ret;
    }
  }
}
