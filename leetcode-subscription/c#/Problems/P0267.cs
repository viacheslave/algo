using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-permutation-ii/
  ///    Submission: https://leetcode.com/submissions/detail/450995844/
  ///    Facebook, Microsoft
  /// </summary>
  internal class P0267
  {
    public class Solution
    {
      public IList<string> GeneratePalindromes(string s)
      {
        if (!CanPermutePalindrome(s))
          return new List<string>();

        var map = s
          .GroupBy(d => d)
          .ToDictionary(c => c.Key, c => c.Count());

        var single = map.Where(d => d.Value % 2 == 1).Select(c => c.Key).SingleOrDefault();
        var doubles = map.Where(s => s.Value != 1).Select(c => (c.Key, c.Value / 2)).ToList();

        var arr = new List<int>();
        foreach (var d in doubles)
          for (var i = 0; i < d.Item2; i++)
            arr.Add((int)d.Key);

        var permutations = GetPermutations(arr);

        var ans = new List<string>();

        foreach (var perm in permutations)
        {
          ans.Add(
            new string(perm.Select(d => (char)d).ToArray()) +
            (single != default ? single.ToString() : "") +
            new string(perm.Reverse().Select(d => (char)d).ToArray())
          );
        }

        return ans;
      }

      private bool CanPermutePalindrome(string s)
      {
        var map = s
          .GroupBy(d => d)
          .Where(d => d.Count() % 2 == 1)
          .ToDictionary(c => c.Key, c => c.Count());

        return map.Count <= 1;
      }

      private IList<IList<int>> GetPermutations(List<int> nums)
      {
        var filled = new List<int>();

        IList<IList<int>> res = new List<IList<int>>();

        Rec(res, filled, nums, nums.Count);

        return res;
      }

      private void Rec(IList<IList<int>> res, List<int> filled, List<int> nums, int left)
      {
        if (left == 0)
        {
          var cand = new List<int>();
          for (var i = 0; i < filled.Count; i++)
            cand.Add(nums[filled[i]]);

          res.Add(cand);
          return;
        }

        for (var i = 0; i < nums.Count; i++)
        {
          if (filled.Contains(i))
            continue;

          var current = i;
          while ((current + 1) < nums.Count)
          {
            if (filled.Contains(current + 1))
            {
              current++;
              continue;
            }

            if (nums[current + 1] != nums[i])
            {
              break;
            }

            current++;
            i = current;
          }

          filled.Add(i);

          Rec(res, filled, nums, left - 1);

          filled.Remove(i);
        }
      }
    }

  }
}
