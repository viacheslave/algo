package codewars;

import java.util.Map;
import java.util.Stack;

/*
* https://www.codewars.com/kata/550f22f4d758534c1100025a
* https://www.codewars.com/kata/550f22f4d758534c1100025a/train/java/61a7c365506648003368767e
* */
public class DirectionsReduction {
  public class DirReduction {
    public static String[] dirReduc(String[] arr) {
      var ans = new Stack<Integer>();

      var map = Map.ofEntries(
        Map.entry("NORTH",1),
        Map.entry("SOUTH",-1),
        Map.entry("WEST",2),
        Map.entry("EAST",-2)
      );

      var mapReversed = Map.ofEntries(
        Map.entry(1, "NORTH"),
        Map.entry(-1, "SOUTH"),
        Map.entry(2, "WEST"),
        Map.entry(-2, "EAST")
      );

      for (int i = 0; i < arr.length; i++) {
        var current =  map.get(arr[i]);

        if (ans.size() > 0) {
          if (current + ans.peek() == 0) {
            ans.pop();
            continue;
          }
        }

        ans.add(current);
      }

      return ans.stream().map(mapReversed::get).toArray(String[]::new);
    }
  }
}
