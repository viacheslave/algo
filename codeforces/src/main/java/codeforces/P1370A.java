package codeforces;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/*
* https://codeforces.com/contest/1370/problem/A
* https://codeforces.com/contest/1370/submission/137274995
* */
public class P1370A {
  public static void main(String[] arg) {
    var scanner = new Scanner(System.in);

    var n = scanner.nextInt();
    var cases = new int[n];

    for (int i = 0; i < cases.length; i++) {
      cases[i] = scanner.nextInt();
    }

    scanner.close();

    var res = new P1370A().solve(n, cases);

    for (int re : res) {
      System.out.println(re);
    }
  }

  public int[] solve(int n, int[] nums) {
    var res = new int[n];

    for (int i = 0; i < nums.length; i++) {
      res[i] = nums[i] / 2;
    }

    return res;
  }
}
