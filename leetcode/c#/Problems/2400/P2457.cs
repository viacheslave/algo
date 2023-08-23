namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-addition-to-make-integer-beautiful/
///    Submission: https://leetcode.com/problems/minimum-addition-to-make-integer-beautiful/submissions/833297089/
/// </summary>
internal class P2457
{
  public class Solution
  {
    public long MakeIntegerBeautiful(long n, int target)
    {
      var arr = new int[12 + 1];

      // fill array
      var num = n;
      var digit = arr.Length - 1;
      while (num > 0)
      {
        arr[digit] = (int)(num % 10);
        digit--;
        num /= 10;
      }

      var sum = arr.Sum();

      digit = arr.Length - 1;
      while (sum > target)
      {
        if (arr[digit] == 0)
        {
          digit--;
          continue;
        }

        sum -= arr[digit];
        arr[digit] = 0;

        sum += 1;
        arr[digit - 1]++;

        var carry = digit - 1;
        while (arr[carry] > 9)
        {
          sum -= arr[carry];
          arr[carry] = 0;

          sum += 1;
          arr[carry - 1]++;

          carry--;
        }
      }

      var final = long.Parse(string.Join("", arr.Select(ch => ch.ToString())));
      return final - n;
    }
  }
}
