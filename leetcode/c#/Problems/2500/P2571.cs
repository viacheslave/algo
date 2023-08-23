namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-operations-to-reduce-an-integer-to-0/
///    Submission: https://leetcode.com/problems/minimum-operations-to-reduce-an-integer-to-0/submissions/909087155/
/// </summary>
internal class P2571
{
  public class Solution
  {
    public int MinOperations(int n)
    {
      var arr = new int[32];

      for (int i = 0; i < 32; i++)
      {
        arr[i] = n % 2;
        n >>= 1;
      }

      var ans = 0;

      // optimize for add operations
      for (int p = 0; p < arr.Length; p++)
      {
        if (arr[p] == 1)
        {
          var s = p;
          while (arr[s] == 1)
            s++;

          if (s - p == 1)
            continue;

          for (var i = p; i < s; i++)
            arr[i] = 0;

          arr[s] = 1;

          ans++;
        }
      }

      // all is left is remove operation set
      ans += arr.Count(d => d == 1);
      return ans;
    }
  }
}
