namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-deletions-to-make-array-divisible/
///    Submission: https://leetcode.com/submissions/detail/750308478/
/// </summary>
internal class P2344
{
  public class Solution
  {
    public int MinOperations(int[] nums, int[] numsDivide)
    {
      // idea
      // get GCD of all numbers in numsDivide
      // GCD is the top bound - check all dividers od GCD

      var numsDict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      var numKeys = numsDict.Keys.OrderBy(x => x).ToArray();

      var numsDivideDistinct = numsDivide.Distinct().ToArray();

      // get GCD of all numsDivide
      var gcd = numsDivideDistinct[0];
      for (int i = 1; i < numsDivideDistinct.Length; i++)
      {
        gcd = GetGcd(gcd, numsDivideDistinct[i]);
      }

      for (int i = 1; i <= gcd; i++)
      {
        if (gcd % i == 0 && numsDict.ContainsKey(i))
        {
          // binary search
          var left = 0;
          var right = numKeys.Length - 1;
          var midPoint = 0;

          while (left != right)
          {
            if (numKeys[left] == i)
            {
              midPoint = left;
              break;
            }
            if (numKeys[right] == i)
            {
              midPoint = right;
              break;
            }

            var mid = (left + right) >> 1;
            if (numKeys[mid] < i)
              left = mid;
            else
              right = mid;
          }

          var ans = 0;

          for (var j = 0; j < midPoint; j++)
            ans += numsDict[numKeys[j]];

          return ans;
        }
      }

      return -1;
    }

    private int GetGcd(int a, int b)
    {
      if (a % b == 0)
        return b;

      if (b % a == 0)
        return a;

      if (a == b)
        return a;

      return a > b
        ? GetGcd((a - b) % b, b)
        : GetGcd(a, (b - a) % a);
    }
  }
}
