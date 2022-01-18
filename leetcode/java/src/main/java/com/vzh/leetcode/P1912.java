package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/design-movie-rental-system/
 * Submission: https://leetcode.com/submissions/detail/589151059/
 */
public class P1912 {
  class MovieRentingSystem {
    private HashMap<ShopMovie, Integer> prices = new HashMap<>();

    private HashMap<Integer, TreeSet<ShopPrice>> movies = new HashMap<>();
    private TreeSet<Rented> rented = new TreeSet<Rented>();

    public MovieRentingSystem(int n, int[][] entries) {
      for (var e : entries) {
        movies.putIfAbsent(e[1], new TreeSet<>());
        movies.get(e[1]).add(new ShopPrice(e[0], e[2]));

        prices.put(new ShopMovie(e[0], e[1]), e[2]);
      }
    }

    public List<Integer> search(int movie) {
      if (!movies.containsKey(movie))
        return new ArrayList<>();

      var list = new ArrayList<Integer>(5);
      var index = 1;

      for (var e : movies.get(movie)) {
        list.add(e.shop);

        if (index++ == 5)
          break;
      }

      return list;
    }

    public void rent(int shop, int movie) {
      movies.get(movie).remove(new ShopPrice(shop, prices.get(new ShopMovie(shop, movie))));
      rented.add(new Rented(shop, movie, prices.get(new ShopMovie(shop, movie))));
    }

    public void drop(int shop, int movie) {
      movies.get(movie).add(new ShopPrice(shop, prices.get(new ShopMovie(shop, movie))));
      rented.remove(new Rented(shop, movie, prices.get(new ShopMovie(shop, movie))));
    }

    public List<List<Integer>> report() {
      var list = new ArrayList<List<Integer>>(5);
      var index = 1;

      for (var e : rented) {
        list.add(List.of(e.shop, e.movie));

        if (index++ == 5)
          break;
      }

      return list;
    }

    class ShopMovie {
      public int shop;
      public int movie;

      public ShopMovie(int shop, int movie) {
        this.shop = shop;
        this.movie = movie;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ShopMovie shopMovie = (ShopMovie) o;
        return shop == shopMovie.shop && movie == shopMovie.movie;
      }

      @Override
      public int hashCode() {
        return Objects.hash(shop, movie);
      }
    }

    class ShopPrice implements Comparable<ShopPrice> {
      public int shop;
      public int price;

      public ShopPrice(int shop, int price) {
        this.shop = shop;
        this.price = price;
      }

      @Override
      public int compareTo(ShopPrice o) {
        if (o.price == this.price)
          return this.shop - o.shop;

        return this.price - o.price;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ShopPrice shopPrice = (ShopPrice) o;
        return shop == shopPrice.shop && price == shopPrice.price;
      }

      @Override
      public int hashCode() {
        return Objects.hash(shop, price);
      }
    }

    class Rented implements Comparable<Rented> {
      public int shop;
      public int movie;
      public int price;

      public Rented(int shop, int movie, int price) {
        this.shop = shop;
        this.movie = movie;
        this.price = price;
      }

      @Override
      public int compareTo(Rented o) {
        if (this.price == o.price) {
          if (this.shop == o.shop) {
            return this.movie - o.movie;
          }
          return this.shop - o.shop;
        }
        return this.price - o.price;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Rented rented = (Rented) o;
        return shop == rented.shop && movie == rented.movie && price == rented.price;
      }

      @Override
      public int hashCode() {
        return Objects.hash(shop, movie, price);
      }
    }
  }

}