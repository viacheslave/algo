namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/capitalize-the-title/
///    Submission: https://leetcode.com/submissions/detail/615552160/
/// </summary>
internal class P2129
{
  public class Solution
  {
    public string CapitalizeTitle(string title)
    {
      var ans = new List<string>();

      foreach (var w in title.Split(' '))
      {
        if (w.Length <= 2)
        {
          ans.Add(w.ToLower());
          continue;
        }

        ans.Add(w[0].ToString().ToUpper() + w.Substring(1).ToLower());
      }

      return string.Join(" ", ans);

    }
  }

}
