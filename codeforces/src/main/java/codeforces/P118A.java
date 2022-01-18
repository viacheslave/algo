package codeforces;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.Set;

/*
* https://codeforces.com/contest/118/problem/A
* https://codeforces.com/contest/118/submission/137276697
* */
public class P118A {
  public static void main(String[] arg) {
    var scanner = new Scanner(System.in);

    var str = scanner.next();

    scanner.close();

    var res = new P118A().solve(str);
    System.out.println(res);
  }

  public String solve(String str) {
    var sb = new StringBuilder(str);
    var set = Set.of('a', 'o', 'u', 'i', 'e', 'y');

    for (int i = 0; i < str.length(); i++) {
      if (Character.isUpperCase(sb.charAt(i)))
        sb.setCharAt(i, (char)(sb.charAt(i) + 32));
    }

    var ans = new StringBuilder();

    for (int i = 0; i < str.length(); i++) {
      if (set.contains(sb.charAt(i)))
        continue;

      ans.append('.');
      ans.append(sb.charAt(i));
    }

    return ans.toString();
  }
}
