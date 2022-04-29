namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/cells-in-a-range-on-an-excel-sheet/
///    Submission: https://leetcode.com/submissions/detail/689857714/
/// </summary>
internal class P2194
{
  public class Solution
  {
    public IList<string> CellsInRange(string s)
    {
      var aleft = s[0];
      var aright = s[3];

      var dleft = s[1];
      var dright = s[4];

      var ans = new List<string>();

      for (var i = aleft; i <= aright; i++)
      {
        for (var j = dleft; j <= dright; j++)
        {
          ans.Add($"{i}{j}");
        }
      }

      return ans;
    }
  }
}
