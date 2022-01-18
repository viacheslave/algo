using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/556deca17c58da83c00002db
  ///   https://www.codewars.com/kata/reviews/559a3e7b8a87c7f6a50000b0/groups/5dff4b4b4225f30001f55db6
  /// </summary>
  public class Xbonacci
  {
    public double[] Tribonacci(double[] signature, int n)
    {
      var ans = new List<double>();
      ans.AddRange(signature);

      while (ans.Count < n)
      {
        ans.Add(ans[ans.Count - 1] + ans[ans.Count - 2] + ans[ans.Count - 3]);
      }

      return ans.Take(n).ToArray();
    }
  }
}
