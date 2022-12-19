namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-value-after-replacing-with-sum-of-prime-factors/
///    Submission: https://leetcode.com/problems/smallest-value-after-replacing-with-sum-of-prime-factors/submissions/862038190/
/// </summary>
internal class P2508
{
  public class Solution
  {
    public int SmallestValue(int n)
    {
      var primes = new List<int>();

      while (true)
      {
        var m = n;
        var sum = 0;
        var primesIndex = 0;

        while (m > 1)
        {
          if (primesIndex >= primes.Count)
          {
            // get next prime
            var lastPrime = primes.Count == 0 ? 1 : primes[^1];
            for (var p = lastPrime + 1; ; p++)
            {
              var isPrime = true;
              for (var i = 2; i * i <= p; i++)
              {
                if (p % i == 0)
                {
                  isPrime = false;
                  break;
                }
              }

              if (isPrime)
              {
                primes.Add(p);
                break;
              }
            }
          }

          // primesIndex is set
          while (m % primes[primesIndex] == 0)
          {
            m = m / primes[primesIndex];
            sum += primes[primesIndex];
          }

          primesIndex++;
        }

        if (sum != n)
        {
          n = sum;
          continue;
        }

        break;
      }

      return n;
    }
  }
}
