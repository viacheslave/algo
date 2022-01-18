package codeforces;

import java.util.ArrayList;
import java.util.Scanner;

/*
* https://codeforces.com/contest/1560/problem/A
* https://codeforces.com/contest/1560/submission/137276232
* */
public class P1560A {
  public static void main(String[] arg) {
    var scanner = new Scanner(System.in);

    var n = scanner.nextInt();
    var cases = new int[n];

    for (int i = 0; i < cases.length; i++) {
      cases[i] = scanner.nextInt();
    }

    scanner.close();

    var res = new P1560A().solve(n, cases);

    for (int re : res) {
      System.out.println(re);
    }
  }

  public int[] solve(int n, int[] nums) {
    var res = new int[n];

    var arr = new ArrayList<Integer>();
    var j = 0;

    while (true) {
      j++;
      if (j % 3 == 0 || j % 10 == 3)
        continue;
      arr.add(j);
      if (arr.size() == 1000 + 1)
        break;
    }

    for (int i = 0; i < nums.length; i++) {
      res[i] = arr.get(nums[i] - 1);
    }

    return res;
  }
}
