namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/prime-pairs-with-target-sum/
///    Submission: https://leetcode.com/problems/prime-pairs-with-target-sum/submissions/1025892548/
/// </summary>
internal class P2761
{
  public class Solution
  {
    public IList<IList<int>> FindPrimePairs(int n)
    {
      var ans = new List<IList<int>>();

      for (int num = 2; num <= n / 2; num++)
      {
        if (IsPrime(num) && IsPrime(n - num))
        {
          ans.Add(new List<int> { num, n - num });
        }
      }

      return ans;
    }

    private bool IsPrime(int num)
    {
      if (num <= 3)
        return true;

      for (int i = 2; i * i <= num; i++)
      {
        if (num % i == 0)
        {
          return false;
        }
      }

      return true;
    }
  }

}
