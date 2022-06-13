namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/successful-pairs-of-spells-and-potions/
///    Submission: https://leetcode.com/submissions/detail/721038818/
/// </summary>
internal class P2300
{
  public class Solution
  {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
      Array.Sort(potions);

      var ans = new int[spells.Length];

      for (int i = 0; i < spells.Length; i++)
      {
        // binary search
        var index = GetIndex(potions, spells[i], success);
        ans[i] = potions.Length - index;
      }

      return ans;
    }

    private int GetIndex(int[] potions, int spell, long success)
    {
      var l = 0;
      var r = potions.Length - 1;

      while (true)
      {
        if (r - l <= 1)
        {
          if (1L * potions[l] * spell >= success)
            return l;
          if (1L * potions[r] * spell >= success)
            return r;
          return potions.Length;
        }

        var mid = (l + r) >> 1;
        if (1L * potions[mid] * spell >= success)
        {
          r = mid;
        }
        else
        {
          l = mid;
        }
      }
    }
  }
}
