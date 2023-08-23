namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-valid-words-for-each-puzzle/
///    Submission: https://leetcode.com/submissions/detail/636430811/
/// </summary>
internal class P1178
{
  public class Solution
  {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
    {
      var puzzleMaxLength = 7;

      var wordMasks = words.Select(GetMask).Where(x => x.count <= puzzleMaxLength).ToArray();
      var puzzleMasks = puzzles.Select(GetMask).ToArray();

      (int mask, int count) GetMask(string w)
      {
        var value = 0;
        var set = new HashSet<int>();

        foreach (var ch in w)
        {
          value |= 1 << (ch - 97);
          set.Add(ch - 97);
        }
        return (value, set.Count);
      }

      var ans = new int[puzzles.Length];

      for (var i = 0; i < puzzles.Length; i++)
      {
        var firstCh = 1 << (puzzles[i][0] - 97);

        foreach (var w in wordMasks)
        {
          if ((w.mask & firstCh) != firstCh)
            continue;

          if ((puzzleMasks[i].mask & w.mask) == w.mask)
            ans[i]++;
        }
      }

      return ans.ToList();
    }
  }
}
