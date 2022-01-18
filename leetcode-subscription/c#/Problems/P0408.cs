using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-word-abbreviation/
  ///    Submission: https://leetcode.com/submissions/detail/451004836/
  ///    Facebook
  /// </summary>
  internal class P0408
  {
    public class Solution
    {
      public bool ValidWordAbbreviation(string word, string abbr)
      {
        var items = new List<string>();
        var number = new List<char>();

        for (var i = 0; i < abbr.Length; i++)
        {
          if (i == 0)
          {
            if (char.IsLetter(abbr[i]))
              items.Add(abbr[i].ToString());
            else
              number.Add(abbr[i]);
          }
          else
          {
            // 11
            if (char.IsDigit(abbr[i]) && char.IsDigit(abbr[i - 1]))
            {
              number.Add(abbr[i]);
            }
            // 1a
            else if (char.IsLetter(abbr[i]) && char.IsDigit(abbr[i - 1]))
            {
              //number.Add(abbr[i]);
              items.Add(new string(number.ToArray()));
              number = new List<char>();

              items.Add(abbr[i].ToString());
            }
            // a1
            else if (char.IsDigit(abbr[i]) && char.IsLetter(abbr[i - 1]))
            {
              number.Add(abbr[i]);
            }
            // aa
            else
            {
              items.Add(abbr[i].ToString());
            }
          }
        }

        if (number.Count > 0)
          items.Add(new string(number.ToArray()));

        var index = 0;
        var itemIndex = 0;

        while (true)
        {
          if (itemIndex == items.Count)
          {
            if (index == word.Length)
              return true;
            return false;
          }

          if (index >= word.Length)
            return false;

          if (items[itemIndex].StartsWith("0"))
            return false;

          var res = int.TryParse(items[itemIndex], out var num);
          if (res)
          {
            index += num;
          }
          else
          {
            if (word[index].ToString() != items[itemIndex])
              return false;

            index++;
          }

          itemIndex++;
        }

        return true;
      }
    }
  }
}
