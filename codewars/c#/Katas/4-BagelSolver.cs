using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/54bd6b4c956834c9870001a1
  ///   https://www.codewars.com/kata/reviews/59b1398e3b1e83dc3100000f/groups/59b15f6cf322e511da0027eb
  /// </summary>
  class BagelSolver
  {
    public static BagelDefinition Bagel
    {
      get
      {
        var b = new BagelDefinition();
        typeof(BagelDefinition).GetProperty("Value").SetValue(b, 4);
        return b;
      }
    }

    public sealed class BagelDefinition
    {
      public int Value { get; private set; } = 3;
    }
  }
}
