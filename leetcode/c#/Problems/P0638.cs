namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shopping-offers/
///    Submission: https://leetcode.com/submissions/detail/417407097/
/// </summary>
internal class P0638
{
  public class Solution
  {
    private int _minSpent = int.MaxValue;

    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
      special = special.Where(sp => Fits(sp, needs)).ToList();

      var need = needs.ToList();

      DFS(need, special, 0, price);

      var pureSpent = 0;
      for (var i = 0; i < need.Count; i++)
        pureSpent += price[i] * need[i];

      return Math.Min(_minSpent, pureSpent);
    }

    private void DFS(List<int> need, IList<IList<int>> special, int spent, IList<int> price)
    {
      var midspent = spent;

      for (var i = 0; i < need.Count; i++)
        midspent += price[i] * need[i];

      if (midspent < _minSpent)
        _minSpent = midspent;

      for (var i = 0; i < special.Count; i++)
      {
        var sp = special[i];
        if (!Fits(sp, need))
          continue;

        var nextNeed = need.ToList();
        for (var j = 0; j < need.Count; j++)
          nextNeed[j] = need[j] - sp[j];

        DFS(nextNeed, special, spent + sp[^1], price);
      }
    }

    private bool Fits(IList<int> sp, IList<int> need)
    {
      for (var i = 0; i < need.Count; i++)
        if (sp[i] > need[i])
          return false;

      return true;
    }
  }
}
