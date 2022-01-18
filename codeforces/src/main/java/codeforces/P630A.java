package codeforces;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/*
* https://codeforces.com/contest/630/problem/A
* https://codeforces.com/contest/630/submission/137274593
* */
public class P630A {
  public static void main(String[] arg) {
    var scanner = new Scanner(System.in);

    var n = scanner.next();

    scanner.close();

    var res = new P630A().solve(n);
    System.out.println(res);
  }

  public int solve(String n) {
    return 25;
  }
}
