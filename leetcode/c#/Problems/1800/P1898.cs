namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-removable-characters/
///    Submission: https://leetcode.com/submissions/detail/715091014/
/// </summary>
internal class P1898
{
  public class Solution
  {
    public int MaximumRemovals(string s, string p, int[] removable)
    {
      // binary search
      // substring check is cheap

      var min = 0;
      var max = removable.Length - 1;

      while (true)
      {
        if (max - min <= 1)
        {
          if (IsSubstring(s, p, removable, max))
            return max + 1;

          if (IsSubstring(s, p, removable, min))
            return min + 1;

          return 0;
        }

        var mid = (max + min) >> 1;
        if (IsSubstring(s, p, removable, mid))
        {
          min = mid;
        }
        else
        {
          max = mid;
        }
      }
    }

    private static bool IsSubstring(string s, string p, int[] removable, int resrictedCount)
    {
      var set = new HashSet<int>(removable.Take(resrictedCount + 1));

      var index = 0;
      for (var i = 0; i < s.Length; i++)
      {
        if (set.Contains(i))
          continue;

        if (s[i] == p[index])
        {
          if (index == p.Length - 1)
            return true;

          index++;
        }
      }

      return false;
    }
  }
}
