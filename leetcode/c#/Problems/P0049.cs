namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/group-anagrams/
///    Submission: https://leetcode.com/submissions/detail/234323898/
/// </summary>
internal class P0049
{
  public class Solution
  {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
      var d = new Dictionary<string, IList<string>>();


      foreach (var str in strs)
      {
        var arr = str.ToCharArray();
        Array.Sort(arr);
        var s = new string(arr);

        if (!d.ContainsKey(s))
          d[s] = new List<string>();

        d[s].Add(str);
      }

      return d.Values.ToList();
    }
  }
}
