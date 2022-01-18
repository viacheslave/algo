using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1
  ///   https://www.codewars.com/kata/reviews/5d703840d58c8500012da8bd/groups/5e04cc3f8c89df0001459917
  /// </summary>
  public class SnailSolution
  {
    public static int[] Snail(int[][] array)
    {
      if (array.Length == 0 || array[0].Length == 0)
        return new int[0];

      var list = new List<int>() { array[0][0] };

      var direction = 0;
      var x = 0;
      var y = 0;

      var xminBorder = -1;
      var yminBorder = -1;
      var xmaxBorder = array.Length;
      var ymaxBorder = array[0].Length;

      while (true)
      {
        // can move?
        var can =
            (direction % 4 == 0 && (y + 1) != ymaxBorder) ||
            (direction % 4 == 1 && (x + 1) != xmaxBorder) ||
            (direction % 4 == 2 && (y - 1) != yminBorder) ||
            (direction % 4 == 3 && (x - 1) != xminBorder);

        if (!can)
        {
          direction++;

          if (direction % 4 == 1)
            xminBorder++;
          if (direction % 4 == 2)
            ymaxBorder--;
          if (direction % 4 == 3)
            xmaxBorder--;
          if (direction % 4 == 0)
            yminBorder++;

          var can2 =
              (direction % 4 == 0 && (y + 1) != ymaxBorder) ||
              (direction % 4 == 1 && (x + 1) != xmaxBorder) ||
              (direction % 4 == 2 && (y - 1) != yminBorder) ||
              (direction % 4 == 3 && (x - 1) != xminBorder);

          if (!can2)
            break;
        }

        // move
        if (direction % 4 == 0)
          y++;

        if (direction % 4 == 1)
          x++;

        if (direction % 4 == 2)
          y--;

        if (direction % 4 == 3)
          x--;

        list.Add(array[x][y]);

      }

      return list.ToArray();
    }
  }
}
