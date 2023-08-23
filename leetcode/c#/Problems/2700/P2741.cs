namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/special-permutations/
///    Submission: https://leetcode.com/problems/special-permutations/submissions/983128197/
/// </summary>
internal class P2741
{
  public class Solution
  {
    public int SpecialPerm(int[] nums)
    {
      var length = nums.Length;

      // lastIndex, mask
      var dpp = new Dictionary<int, int>[length];

      // initial state
      for (var index = 0; index < length; index++)
      {
        dpp[index] = new Dictionary<int, int>() { [1 << index] = 1 };
      }

      for (var i = 1; i < length; i++)
      {
        var nextDpp = new Dictionary<int, int>[length];

        for (int lastIndex = 0; lastIndex < length; lastIndex++)
        {
          if (dpp[lastIndex] is null)
            continue;

          for (int nextIndex = 0; nextIndex < length; nextIndex++)
          {
            foreach (var item in dpp[lastIndex])
            {
              var mask = item.Key;
              var value = item.Value;

              if ((mask & (1 << nextIndex)) == 0)
              {
                var nextMask = mask | (1 << nextIndex);

                if (nums[lastIndex] % nums[nextIndex] == 0 || nums[nextIndex] % nums[lastIndex] == 0)
                {
                  nextDpp[nextIndex] ??= new Dictionary<int, int>();
                  nextDpp[nextIndex][nextMask] = nextDpp[nextIndex].ContainsKey(nextMask)
                    ? nextDpp[nextIndex][nextMask] + value
                    : value;

                  nextDpp[nextIndex][nextMask] %= 1_000_000_007;
                }
              }
            }
          }
        }

        dpp = nextDpp;
      }

      var ans = 0;

      foreach (var item in dpp)
      {
        if (item is null)
          continue;

        foreach (var k in item)
        {
          ans += k.Value;
          ans %= 1_000_000_007;
        }
      }

      return ans;
    }
  }
}
