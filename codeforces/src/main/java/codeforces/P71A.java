package codeforces;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/*
* https://codeforces.com/contest/71/problem/A
* https://codeforces.com/contest/71/submission/136740579
* */
public class P71A {
  public static void main(String[] arg) {
    var scanner = new Scanner(System.in);

    var n = scanner.nextInt();
    var cases = new String[n];

    for (int i = 0; i < cases.length; i++) {
      cases[i] = scanner.next();
    }

    scanner.close();

    var res = new P71A().solve(n, cases);

    for (String re : res) {
      System.out.println(re);
    }
  }

  public List<String> solve(int n, String[] words) {
    var res = new ArrayList<String>();

    for (var w : words) {
      if (w.length() <= 10) {
        res.add(w);
      }
      else {
        String sb = String.valueOf(w.charAt(0)) +
          (w.length() - 2) +
          w.charAt(w.length() - 1);
        res.add(sb);
      }
    }

    return res;
  }
}
