namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/apply-discount-to-prices/
///    Submission: https://leetcode.com/submissions/detail/712026207/
/// </summary>
internal class P2288
{
  public class Solution
  {
    public string DiscountPrices(string sentence, int discount)
    {
      var words = sentence.Split(' ');

      var ans = new List<string>();

      foreach (var word in words)
      {
        if (word.StartsWith('$'))
        {
          var vstr = word[1..];
          if (!vstr.Contains('e') && double.TryParse(vstr, out var value))
          {
            value = value * (100 - discount) / 100d;
            var newWord = $"${value:f2}";

            ans.Add(newWord);
            continue;
          }
        }

        ans.Add(word);
      }

      return string.Join(' ', ans);
    }
  }
}
