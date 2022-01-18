package codewars;

/*
* https://www.codewars.com/kata/5541f58a944b85ce6d00006a
* https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/java/61a6818462d24000312a945f
* */
public class ProductOfConsecutiveFibNumbers {
  public class ProdFib { // must be public for codewars

    public static long[] productFib(long prod) {
      var fib0 = 1L;
      var fib1 = 1L;

      for (;;) {
        if (fib0 * fib1 == prod)
          return new long[] {fib0, fib1, 1};

        if (fib0 * fib1 > prod)
          return new long[] {fib0, fib1, 0};

        var fib2 = fib0 + fib1;
        fib0 = fib1;
        fib1 = fib2;
      }
    }
  }
}
