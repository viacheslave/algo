
package binarysearch;

import binarysearch.templates.Tree;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Highest-Volume-Stocks
 * Submission: https://binarysearch.com/problems/Highest-Volume-Stocks/submissions/7365325
 */
public class P0778 {
  class StockMarket {
    private TreeSet<Stock> set = new TreeSet<>();
    private Map<String, Stock> map = new HashMap<>();

    public StockMarket(String[] stocks, int[] amounts) {
      for (int i = 0; i < stocks.length; i++) {
        add(stocks[i], amounts[i]);
      }
    }

    public void add(String s, int amount) {
      Stock stock;
      if (map.containsKey(s)) {
        stock = map.get(s);

        set.remove(stock);
        stock.amount += amount;
      }
      else {
        stock = new Stock(s, amount);
      }

      set.add(stock);
      map.put(s, stock);
    }

    public String[] top(int k) {
      var count = 0;
      var arr = new ArrayList<String>();

      for (var e : set) {
        arr.add(e.name);
        count++;
        if (count == k)
          break;
      }

      return arr.toArray(String[]::new);
    }

    private static class Stock implements Comparable<Stock> {
      public String name;
      public int amount;

      public Stock(String name, int amount) {
        this.name = name;
        this.amount = amount;
      }

      @Override
      public int compareTo(Stock o) {
        if (this.amount == o.amount)
          return Comparator.comparing(Object::toString).compare(this.name, o.name);

        return o.amount - this.amount;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Stock stock = (Stock) o;
        return amount == stock.amount && Objects.equals(name, stock.name);
      }

      @Override
      public int hashCode() {
        return Objects.hash(name, amount);
      }
    }
  }
}