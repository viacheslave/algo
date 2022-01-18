using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-3-march-15th-march-21st/3675/
  ///   
  /// </summary>
  internal class Mar17
  {
    public class Solution
    {
      private readonly Random _rnd = new Random((int)DateTime.Now.Ticks);

      private readonly double _r;
      private (double, double) _c;

      public Solution(double radius, double x_center, double y_center)
      {
        _r = radius;
        _c = (x_center, y_center);
      }

      public double[] RandPoint()
      {
        double rx = 1, ry = 1;
        while ((rx * rx) + (ry * ry) > 1)
        {
          rx = _rnd.NextDouble();
          ry = _rnd.NextDouble();
        }

        var coeffx = _rnd.Next(2) % 2 == 0 ? 1 : -1;
        var coeffy = _rnd.Next(2) % 2 == 0 ? 1 : -1;

        var p = ((rx * coeffx * _r) + _c.Item1, (ry * coeffy * _r) + _c.Item2);

        return new double[] { p.Item1, p.Item2 };
      }
    }


    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(radius, x_center, y_center);
     * double[] param_1 = obj.RandPoint();
     */
  }
}
