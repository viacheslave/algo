namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies/
///    Submission: https://leetcode.com/submissions/detail/606934810/
/// </summary>
internal class P2115
{
  public class Solution
  {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
      var sup = supplies.ToHashSet();

      var map = new Dictionary<string, IList<string>>();

      for (var i = 0; i < ingredients.Count; i++)
      {
        map[recipes[i]] = ingredients[i];
      }

      var recp = recipes.ToHashSet();
      var iniCreated = new HashSet<string>();

      for (var i = 0; i < ingredients.Count; i++)
      {
        var rec = recipes[i];
        var ing = ingredients[i];

        var can = true;
        foreach (var j in ing)
        {
          can = can && (sup.Contains(j));
        }

        if (can)
        {
          iniCreated.Add(rec);
          recp.Remove(rec);
        }
      }

      while (true)
      {
        var created = new HashSet<string>();

        foreach (var r in recp)
        {
          var ing = map[r];

          var can = true;
          foreach (var j in ing)
          {
            can = can && (sup.Contains(j) || iniCreated.Contains(j));
          }

          if (can)
          {
            iniCreated.Add(r);
            created.Add(r);
          }
        }

        if (created.Count == 0)
        {
          break;
        }
        else
        {
          foreach (var item in created)
          {
            recp.Remove(item);
          }

          created.Clear();
        }
      }

      return iniCreated.ToList();
    }
  }
}
