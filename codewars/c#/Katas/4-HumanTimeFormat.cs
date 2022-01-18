using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52742f58faf5485cae000b9a
  ///   https://www.codewars.com/kata/reviews/5a2e31d863ed22c2610005c5/groups/5e00e29b8c89df0001673760
  /// </summary>
  public class HumanTimeFormat
  {
    public static string formatDuration(int seconds)
    {
      if (seconds == 0)
        return "now";

      var words = new string[] {
      "year",
      "day",
      "hour",
      "minute",
      "second"
    };

      var values = new int[5];

      values[4] = seconds % 60;

      values[0] = seconds / (60 * 60 * 24 * 365);
      seconds -= values[0] * 60 * 60 * 24 * 365;

      values[1] = seconds / (60 * 60 * 24);
      seconds -= values[1] * 60 * 60 * 24;

      values[2] = seconds / (60 * 60);
      seconds -= values[2] * 60 * 60;

      values[3] = seconds / (60);

      for (var i = 0; i < 5; i++)
      {
        if (values[i] == 0)
        {
          words[i] = "";
          continue;
        }

        words[i] = values[i] + " " + words[i] + (values[i] > 1 ? "s" : "");
      }

      var ans = string.Join(", ", words.Where(w => w != ""));

      var lastComma = ans.LastIndexOf(',');
      if (lastComma != -1)
        ans = new StringBuilder(ans).Replace(",", " and", lastComma, 1).ToString();

      return ans;
    }
  }
}
