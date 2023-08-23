namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-k-mirror-numbers/
///    Submission: https://leetcode.com/submissions/detail/590618933/
/// </summary>
internal class P2081
{
  public class Solution
  {
    public long KMirror(int k, int n)
    {
      var set = new HashSet<long>();

      for (var i = 0; ; i++)
      {
        foreach (var number in GenerateOddLength(i))
        {
          var knum = ToBase(number, k);
          if (IsPalindrome(knum))
          {
            set.Add(number);
            if (set.Count == n)
            {
              return set.Sum();
            }
          }
        }
      }
    }

    private IEnumerable<long> GenerateOddLength(int digits)
    {
      if (digits == 0)
      {
        for (var j = 1; j <= 9; j++)
          yield return j;
      }

      var start = (int)Math.Pow(10, digits);

      // generate mm, nn ...
      for (var i = start; i < (int)Math.Pow(10, digits + 1); i++)
      {
        var str = i.ToString();
        yield return long.Parse(str + new string(str.Reverse().ToArray()));
      }

      // generate m0m, m1m ..., n0n, n1n ...
      for (var i = start; i < (int)Math.Pow(10, digits + 1); i++)
      {
        for (var j = 0; j <= 9; j++)
        {
          var str = i.ToString();
          yield return long.Parse(str + j.ToString() + new string(str.Reverse().ToArray()));
        }
      }
    }

    private bool IsPalindrome(string knum)
    {
      for (var i = 0; i < knum.Length / 2; i++)
        if (knum[i] != knum[knum.Length - 1 - i])
          return false;

      return true;
    }

    public static string ToBase(long decimalNumber, int radix)
    {
      const int BitsInLong = 64;
      const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

      if (decimalNumber == 0)
        return "0";

      var index = BitsInLong - 1;
      var currentNumber = Math.Abs(decimalNumber);
      var charArray = new char[BitsInLong];

      while (currentNumber != 0)
      {
        int remainder = (int)(currentNumber % radix);
        charArray[index--] = Digits[remainder];
        currentNumber /= radix;
      }

      var result = new string(charArray, index + 1, BitsInLong - index - 1);
      if (decimalNumber < 0)
      {
        result = "-" + result;
      }

      return result;
    }
  }



}
