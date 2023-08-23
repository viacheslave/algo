namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/sort-vowels-in-a-string/
///    Submission: https://leetcode.com/problems/sort-vowels-in-a-string/submissions/1028003805/
/// </summary>
internal class P2785
{
  public class Solution
  {
    public string SortVowels(string s)
    {
      var vowels = new HashSet<char>
    {
      'A',
      'E',
      'I',
      'O',
      'U',

      'a',
      'e',
      'i',
      'o',
      'u',
    };

      var arr = s.ToCharArray();

      var v = arr
        .Select((c, i) => (c, i))
        .Where(c => vowels.Contains(c.c))
        .OrderBy(c => c.c)
        .Select(c => c.c)
        .ToArray();

      var index = 0;
      for (int i = 0; i < s.Length; i++)
      {
        if (vowels.Contains(s[i]))
        {
          arr[i] = v[index];
          index++;
        }
      }

      return new string(arr);
    }
  }
}
