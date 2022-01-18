package codeforces;

import java.util.Scanner;

/*
* https://codeforces.com/contest/4/problem/A
* https://codeforces.com/contest/4/submission/136740936
* */
public class P4A {
  public static void main(String[] arg)  {
    var scanner = new Scanner(System.in);
    var w = new Scanner(System.in).nextLong();
    scanner.close();

    var ans = w % 2 == 0 && w > 2 ? "Yes" : "No";
    System.out.println(ans);
  }
}
