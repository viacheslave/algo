using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/563cf89eb4747c5fb100001b
  ///   https://www.codewars.com/kata/reviews/5664c75243bafc132400017a/groups/5dff3cfd4ebc2000018a0c3f
  /// </summary>
  public class RemoveTheMinimum
  {
    public static List<int> RemoveSmallest(List<int> numbers)
    {
      var list = new List<int>(numbers);

      int min = int.MaxValue;
      int minIndex = -1;

      for (var i = 0; i < list.Count; i++)
      {
        if (minIndex == -1)
        {
          minIndex = 0;
          min = list[minIndex];
          continue;
        }

        if (list[i] < min)
        {
          min = list[i];
          minIndex = i;
        }
      }

      if (minIndex != -1)
        list.RemoveAt(minIndex);

      return list;
    }
  }
}
