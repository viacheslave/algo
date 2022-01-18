package codewars;

import java.util.ArrayList;
import java.util.TreeMap;

/*
* https://www.codewars.com/kata/54d512e62a5e54c96200019e
* https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/java/61a682b51b3bc9000e417d2b
* */
public class PrimesInNumbers {
  public class PrimeDecomp {

    public static String factors(int n) {
      var treeMap = new TreeMap<Integer, Integer>();

      var fct = new ArrayList<Integer>();
      for (var i = 2; i <= n; i++) {
        if (n % i != 0) {
          continue;
        }

        while (n % i == 0) {
          n /= i;
          treeMap.put(i, treeMap.getOrDefault(i, 0) + 1);
        }
      }

      var sb = new StringBuilder();
      for (var e : treeMap.entrySet()) {
        sb.append("(").append(e.getKey()).append((e.getValue() == 1) ? "" : "**" + e.getValue()).append(")");
      }

      return sb.toString();
    }
  }
}
