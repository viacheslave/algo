namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/palindrome-pairs/
///    Submission: https://leetcode.com/submissions/detail/718987237/
/// </summary>
internal class P0336
{
  public class Solution
  {
    public IList<IList<int>> PalindromePairs(string[] words)
    {
      var masks = new List<int>();

      // calculate each word's mask

      foreach (var word in words)
      {
        var mask = 0;
        for (int i = 0; i < word.Length; i++)
        {
          mask ^= 1 << (word[i] - 97);
        }

        masks.Add(mask);
      }

      var ans = new List<IList<int>>();

      for (int i = 0; i < masks.Count - 1; i++)
      {
        for (int j = i + 1; j < masks.Count; j++)
        {
          var a = masks[i];
          var b = masks[j];

          var x = a ^ b;

          // either xor is 0 or there's only one ch (bit 1 somewhere)

          if ((x & (x - 1)) == 0 || x == 0)
          {
            if (IsPalindrome(words[i], words[j]))
            {
              ans.Add(new List<int> { i, j });
            }

            if (IsPalindrome(words[j], words[i]))
            {
              ans.Add(new List<int> { j, i });
            }
          }
        }
      }

      return ans;
    }

    private static bool IsPalindrome(string a, string b)
    {
      var length = a.Length + b.Length;

      for (var i = 0; i < length / 2; i++)
      {
        var j = length - 1 - i;

        var l = i < a.Length ? a[i] : b[i - a.Length];
        var r = j < a.Length ? a[j] : b[j - a.Length];

        if (l != r)
          return false;
      }

      return true;
    }
  }

}
