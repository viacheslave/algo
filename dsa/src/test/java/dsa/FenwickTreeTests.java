package dsa;

import dsa.FenwickTree;
import org.junit.*;

public class FenwickTreeTests {
  private final int[] arr = new int[] {1,2,3,4,5,6,7,8,9,10};

  @Test
  public void sumTests() {
    FenwickTree tree = new FenwickTree(arr);

    Assert.assertEquals(1, tree.sum(1, 1));
    Assert.assertEquals(5, tree.sum(5, 5));
    Assert.assertEquals(10, tree.sum(10, 10));

    Assert.assertEquals(2 + 3 + 4, tree.sum(2, 4));
    Assert.assertEquals(5 + 6 + 7 + 8 + 9 + 10, tree.sum(5, 10));
  }

  @Test
  public void addTests() {
    FenwickTree tree = new FenwickTree(arr);

    tree.add(1, 100);

    Assert.assertEquals((100 + 1), tree.sum(1, 1));
    Assert.assertEquals((100 + 1) + 2, tree.sum(1, 2));

    tree.add(7, 700);

    Assert.assertEquals((700 + 7), tree.sum(7, 7));

    Assert.assertEquals((100 + 1) + 2 + 3 + 4 + 5 + 6 + (700 + 7) + 8 + 9 + 10, tree.sum(1, 10));
  }

  @Test
  public void setTests() {
    FenwickTree tree = new FenwickTree(arr);

    tree.set(1, 100);

    Assert.assertEquals((100), tree.sum(1, 1));
    Assert.assertEquals((100) + 2, tree.sum(1, 2));

    tree.set(7, 700);

    Assert.assertEquals((700), tree.sum(7, 7));

    Assert.assertEquals((100) + 2 + 3 + 4 + 5 + 6 + (700) + 8 + 9 + 10, tree.sum(1, 10));
  }
}
