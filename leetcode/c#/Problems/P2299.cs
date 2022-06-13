namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/strong-password-checker-ii/
///    Submission: https://leetcode.com/submissions/detail/721044038/
/// </summary>
internal class P2299
{
  public class Solution
  {
    public bool StrongPasswordCheckerII(string password)
    {
      var spSet = new HashSet<char>("!@#$%^&*()-+");

      if (password.Length < 8)
      {
        return false;
      }

      if (
        !password.Any(c => char.IsDigit(c)) ||
        !password.Any(c => char.IsUpper(c)) ||
        !password.Any(c => char.IsLower(c)) ||
        !password.Any(c => spSet.Contains(c)))
      {
        return false;
      }

      if (password.Length == 1)
      {
        return true;
      }

      for (var i = 1; i < password.Length; i++)
      {
        if (password[i] == password[i - 1])
        {
          return false;
        }
      }

      return true;
    }
  }

}
