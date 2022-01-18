using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52a89c2ea8ddc5547a000863
  ///   https://www.codewars.com/kata/reviews/55937c83091cf8643e0000e7/groups/5dff63034ebc200001867e41
  /// </summary>
  class CanYouGetTheLoop
  {
    public class Kata
    {
      public static int getLoopSize(Node startNode)
      {
        var ans = 0;

        var map = new Dictionary<Node, int>();
        var current = startNode;

        var num = 0;
        while (current != null)
        {
          if (map.ContainsKey(current))
            return num - map[current];

          map[current] = num++;
          current = current.next;
        }

        return ans;
      }
    }

    public class Node
    {
      internal Node next;
    }
  }
}
