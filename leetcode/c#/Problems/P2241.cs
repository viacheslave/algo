namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-an-atm-machine/
///    Submission: https://leetcode.com/submissions/detail/684163284/
/// </summary>
internal class P2241
{
  public class ATM
  {
    long[] notes = new long[5];
    int[] map = new[] { 20, 50, 100, 200, 500 };

    public ATM()
    {

    }

    public void Deposit(int[] banknotesCount)
    {
      for (var i = 0; i < 5; i++)
        notes[i] += banknotesCount[i];
    }

    public int[] Withdraw(int amount)
    {
      var res = new int[5];

      for (var i = 4; i >= 0; i--)
      {
        var div = Math.Min(notes[i], amount / map[i]);
        amount -= (int)(div * map[i]);

        res[i] = (int)div;
      }

      if (amount > 0)
        return new[] { -1 };

      for (var i = 0; i < 5; i++)
        notes[i] -= res[i];

      return res;
    }
  }

  /**
   * Your ATM object will be instantiated and called as such:
   * ATM obj = new ATM();
   * obj.Deposit(banknotesCount);
   * int[] param_2 = obj.Withdraw(amount);
   */

}
