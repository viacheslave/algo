package com.vzh.leetcode;

import java.util.HashSet;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/simple-bank-system/
 * Submission: https://leetcode.com/submissions/detail/572619462/
 */
public class P2043 {
  class Bank {

    private long[] balance;

    public Bank(long[] balance) {
      this.balance = balance;
    }

    public boolean transfer(int account1, int account2, long money) {
      var a1 = account1 - 1;
      var a2 = account2 - 1;

      if (a1 < 0 || a1 >= this.balance.length || a2 < 0 || a2 >= this.balance.length)
        return false;

      if (this.balance[a1] >= money) {
        this.balance[a1] -= money;
        this.balance[a2] += money;
        return true;
      }

      return false;
    }

    public boolean deposit(int account, long money) {
      var a = account - 1;

      if (a < 0 || a >= this.balance.length)
        return false;

      this.balance[a] += money;
      return true;
    }

    public boolean withdraw(int account, long money) {
      var a = account - 1;

      if (a < 0 || a >= this.balance.length || this.balance[a] < money)
        return false;

      this.balance[a] -= money;
      return true;
    }
  }

/**
 * Your Bank object will be instantiated and called as such:
 * Bank obj = new Bank(balance);
 * boolean param_1 = obj.transfer(account1,account2,money);
 * boolean param_2 = obj.deposit(account,money);
 * boolean param_3 = obj.withdraw(account,money);
 */
}