using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52685f7382004e774f0001f7
  ///   https://www.codewars.com/kata/reviews/5577091ee9be66dce500004c/groups/5dff32e68c89df0001e5122e
  /// </summary>
  public class HumanReadableTime
  {
    public static class TimeFormat
    {
      public static string GetReadableTime(int seconds)
      {
        var secs = seconds % 60;
        var mins = ((seconds - secs) / 60) % 60;
        var hrs = ((seconds - secs) / 60) / 60;

        return $"{hrs:D2}:{mins:D2}:{secs:D2}";
      }
    }
  }
}
