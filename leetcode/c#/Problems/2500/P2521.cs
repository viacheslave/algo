namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/distinct-prime-factors-of-product-of-array/
///    Submission: https://leetcode.com/problems/distinct-prime-factors-of-product-of-array/submissions/873249234/
/// </summary>
internal class P2521
{
  public class Solution
  {
    public int DistinctPrimeFactors(int[] nums)
    {
      var ans = 0;

      var primes = GetPrimes(nums.Max());

      foreach (var prime in primes)
      {
        if (nums.Any(n => n % prime == 0))
          ans++;
      }

      return ans;
    }

    private List<int> GetPrimes(int mx)
    {
      var primes = new List<int>();

      for (int p = 2; p <= mx; p++)
      {
        var isprime = true;

        for (var c = 2; c < p; c++)
        {
          if (p % c == 0)
          {
            isprime = false;
            break;
          }
        }

        if (isprime)
          primes.Add(p);
      }

      return primes;
    }
  }
}
