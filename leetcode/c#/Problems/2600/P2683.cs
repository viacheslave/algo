namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/neighboring-bitwise-xor/
///    Submission: https://leetcode.com/problems/neighboring-bitwise-xor/submissions/957005875/
/// </summary>
internal class P2683
{
  public class Solution
  {
    public bool DoesValidArrayExist(int[] derived)
    {
      var length = derived.Length;
      var original = new int[length];

      // start with 1
      original[0] = 1;

      var result = Fill(original, derived);
      if (result)
      {
        return true;
      }

      // start with 0
      original[0] = 0;
      result = Fill(original, derived);

      return result;
    }

    private bool Fill(int[] original, int[] derived)
    {
      for (int i = 0; i < original.Length; i++)
      {
        var value = original[i] ^ derived[i];

        if (i != original.Length - 1)
        {
          original[i + 1] = value;
        }
        else
        {
          return value == original[0];
        }
      }

      // should not happen
      return false;
    }
  }
}
